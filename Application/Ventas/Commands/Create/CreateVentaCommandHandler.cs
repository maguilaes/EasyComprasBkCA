using Application.DTOs;
using Application.Ventas.Queries.GetVentas;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Ventas.Commands.Create
{
    public class CreateVentaCommandHandler : IRequestHandler<CreateVentaCommand, VentasVM>
    {
        private readonly IVentaRepository _entityRepository;
        private readonly IDetVentaRepository _detRepository;
        private readonly IProductoRepository _proRepository;
        private readonly IVentaTransferenciaRepository _transferenciaRepository;
        private readonly IVentaCreditoRepository _creditoRepository;
        private readonly IMapper _mapper;

        public CreateVentaCommandHandler(IMapper mapper, IProductoRepository proRepository,
            IVentaRepository ventaRepository, IVentaCreditoRepository creditoRepository,
            IDetVentaRepository detRepository, IVentaTransferenciaRepository transferenciaRepository
            )
        {
            _entityRepository = ventaRepository;
            _mapper = mapper;
            _detRepository = detRepository;
            _proRepository = proRepository;
            _transferenciaRepository = transferenciaRepository;
            _creditoRepository = creditoRepository;
        }

        public async Task<VentasVM> Handle(CreateVentaCommand request, CancellationToken cancellationToken)
        {
            var carr = request.ProductoLista.ToList();
            string sinStok = string.Empty;
            decimal montoVenta = 0;

            if (carr.Count >= 1)
            {
                foreach (var carrito in request.ProductoLista)
                {
                    var prodSelec = await _proRepository.GetByCodigoAsync(carrito.CodigoProducto);
                    if (prodSelec == null || prodSelec.Stock < carrito.Cantidad)
                    {
                        sinStok = sinStok + carrito.CodigoProducto.ToString() +" - ";
                    }
                    montoVenta = montoVenta + (prodSelec.PrecioVenta * carrito.Cantidad);
                }
                if (sinStok != "")
                {
                    throw new Exception($"ATENCIÓN, stock insuficiente para el/los productos: {sinStok.Substring(0, sinStok.Length - 3)}");
                }
                else
                {
                    var ventaActual = new TrxVentas
                    {
                        IdCliente = request.IdCliente,
                        Coordenadas = request.Coordenadas,
                        IdUsuarioRegistro = request.IdUsuario,
                        FechaRegistro = DateTime.Now.Date,
                        IdcFormaEntrega = request.IdFormaEntrega,
                        IdcFormaPago = request.IdFormaPago,
                        IdcEstadoPago = request.IdEstadoPago,
                        IdcEstadoVenta = request.IdEstadoVenta,
                        IdSucursal = request.IdSucursal,
                        Estado= true,
                        MontoVenta = montoVenta
                    };
                    
                    VentasDto listValue = new VentasDto();
                    
                    var value = await _entityRepository.CreateAsync(ventaActual);

                    if (value != null)
                    {
                        int idVenta = ventaActual.Id;
                        bool band = true;
                        foreach (var carrito in request.ProductoLista)
                        {
                            var prodSelec = await _proRepository.GetByCodigoAsync(carrito.CodigoProducto);
                            prodSelec.Stock = prodSelec.Stock - carrito.Cantidad;
                            var res = await _proRepository.UpdateStockAsync(prodSelec.Id, prodSelec);
                            var carrModel = new Domain.Entity.TrxDetalleVentas
                            {
                                CodigoProducto = carrito.CodigoProducto,
                                Nombre = prodSelec.NombreProducto,
                                Descripcion = prodSelec.Descripcion,
                                IdMedida = prodSelec.IdcMedida,
                                PrecioUnitario = Convert.ToDecimal(prodSelec.PrecioVenta),
                                Cantidad = Convert.ToInt32(carrito.Cantidad),
                                SubTotal = carrito.Cantidad * prodSelec.PrecioVenta,
                                IdVenta = idVenta
                            };
                            
                            var detVenta = await _detRepository.CreateAsync(carrModel);
                            if (detVenta == null)
                            {
                                throw new Exception("Error al insertar el carrito de venta");
                                band = false;
                            }
                        }
                        
                        if (band)
                        {
                            #region REGISTRA VENTA SEGUN FORMA DE PAGO
                            switch (request.IdFormaPago) //venta al credito
                            {
                                case 13: //pago con transferencia
                                    var ventaTransferencia = new TrxVentasTransferencia
                                    {
                                        IdcEstadoTransferencia = 15,  //en proceso
                                        IdCliente = request.IdCliente,
                                        MontoTransferencia = montoVenta,
                                        UrlComprobante ="SinComprobante",
                                        MontoRecibido = 0,
                                        Comentarios = "Sin comentarios",
                                        IdVenta = idVenta,
                                        IdUsuarioRegistro = request.IdUsuario,
                                        FechaRegistro = DateTime.Now.Date,
                                        Estado = true
                                    };
                                    var transfer = await _transferenciaRepository.CreateAsync(ventaTransferencia);
                                    if (transfer == null)
                                    {
                                        throw new Exception("Error al insertar la nota de transferencia");
                                        //band = false;
                                    }
                                    break;
                                case 14: //venta al credito
                                    var ventaCredito = new TrxVentasCredito
                                    {
                                        IdcEstadoCredito = 15,  //en proceso
                                        IdCliente = request.IdCliente,
                                        DeudaInicial = montoVenta,
                                        MontoPagado = 0,
                                        Comentarios = string.Empty,
                                        IdVenta = idVenta,
                                        IdUsuarioRegistro = request.IdUsuario,
                                        FechaRegistro = DateTime.Now.Date,
                                        Estado = true
                                    };
                                    var cred = await _creditoRepository.CreateAsync(ventaCredito);
                                    if (cred == null)
                                    {
                                        throw new Exception("Error al insertar la nota de credito");
                                        //band = false;
                                    }
                                    break;
                            }
                            #endregion REGISTRA VENTA SEGUN FORMA DE PAGO
                            var resDone = _mapper.Map<VentasVM>(value);
                            return resDone;
                        }
                        //throw new KeyNotFoundException($"Error al insertar {request.ProductoLista}");
                    }
                    throw new Exception("Error en la insercion de la compra");
                } 
            }
            throw new Exception("Error, el carrito esta vacio");
        }
    }
}