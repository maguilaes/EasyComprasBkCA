using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirtMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BASCiudades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ciudad = table.Column<string>(type: "varchar(50)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    IdcPais = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BASCiudades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BASClasificadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(150)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    IdTipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BASClasificadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BASDirecciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdcPais = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    IdcCiudad = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Telefono = table.Column<string>(type: "varchar(20)", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(150)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "varchar(10)", nullable: false),
                    Coordenadas = table.Column<string>(type: "varchar(500)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    IdRelacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BASDirecciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BASTipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(150)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BASTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "INIConfig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recurso = table.Column<string>(type: "varchar(50)", nullable: false),
                    Propiedad = table.Column<string>(type: "varchar(50)", nullable: false),
                    Valor = table.Column<string>(type: "varchar(50)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INIConfig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "INIEmail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Para = table.Column<string>(type: "varchar(50)", nullable: false),
                    Asunto = table.Column<string>(type: "varchar(50)", nullable: false),
                    Contenido = table.Column<string>(type: "varchar(50)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INIEmail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NEGClientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documento = table.Column<string>(type: "varchar(20)", nullable: false),
                    Nombres = table.Column<string>(type: "varchar(50)", nullable: false),
                    Apellidos = table.Column<string>(type: "varchar(50)", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    IdSucursal = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuarioRegistro = table.Column<int>(type: "int", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEGClientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NEGCuentaPagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroCuentaPagos = table.Column<string>(type: "varchar(50)", nullable: false),
                    BancoPagos = table.Column<string>(type: "varchar(250)", nullable: false),
                    NombreTitular = table.Column<string>(type: "varchar(150)", nullable: false),
                    DocumentoTitular = table.Column<string>(type: "varchar(20)", nullable: false),
                    UrlQr = table.Column<string>(type: "varchar(1000)", nullable: false),
                    IdSucursal = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuarioRegistro = table.Column<int>(type: "int", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEGCuentaPagos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NEGEmpresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NitEmpresa = table.Column<string>(type: "varchar(20)", nullable: false),
                    NombreEmpresa = table.Column<string>(type: "varchar(250)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Leyenda = table.Column<string>(type: "varchar(250)", nullable: true),
                    UrlLogo = table.Column<string>(type: "varchar(1000)", nullable: true),
                    NombreContacto = table.Column<string>(type: "varchar(250)", nullable: false),
                    TelefonoContacto = table.Column<string>(type: "varchar(20)", nullable: true),
                    IdcCategoria = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Ubicacion = table.Column<bool>(type: "bit", nullable: false),
                    Coordenadas = table.Column<string>(type: "varchar(500)", nullable: true),
                    IdUsuarioRegistro = table.Column<int>(type: "int", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEGEmpresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NEGProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSucursal = table.Column<int>(type: "int", nullable: false),
                    IdcCategoria = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(50)", nullable: false),
                    NombreProducto = table.Column<string>(type: "varchar(200)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(200)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    IdcMedida = table.Column<int>(type: "int", nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UrlImagen = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuarioRegistro = table.Column<int>(type: "int", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEGProductos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NEGSucursales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdcCiudad = table.Column<int>(type: "int", nullable: false),
                    NombreSucursal = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioRegistro = table.Column<int>(type: "int", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEGSucursales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SEGUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "varchar(150)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Clave = table.Column<string>(type: "varchar(50)", nullable: false),
                    IdcRol = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    IdSucursal = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEGUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TRXDetalleVentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoProducto = table.Column<string>(type: "varchar(50)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(150)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(300)", nullable: true),
                    IdMedida = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRXDetalleVentas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TRXVentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    Coordenadas = table.Column<string>(type: "varchar(250)", nullable: true),
                    IdcFormaEntrega = table.Column<int>(type: "int", nullable: false),
                    IdcFormaPago = table.Column<int>(type: "int", nullable: false),
                    IdcEstadoPago = table.Column<int>(type: "int", nullable: false),
                    IdcEstadoVenta = table.Column<int>(type: "int", nullable: false),
                    IdSucursal = table.Column<int>(type: "int", nullable: false),
                    MontoVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdUsuarioRegistro = table.Column<int>(type: "int", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRXVentas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TRXVentasCreditos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdcEstadoCredito = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    DeudaInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoPagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeudaActual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comentarios = table.Column<string>(type: "varchar(1000)", nullable: true),
                    IdVenta = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioRegistro = table.Column<int>(type: "int", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRXVentasCreditos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TRXVentasTransferencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdcEstadoTransferencia = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    MontoTransferencia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UrlComprobante = table.Column<string>(type: "varchar(1000)", nullable: true),
                    MontoRecibido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comentarios = table.Column<string>(type: "varchar(1000)", nullable: true),
                    IdVenta = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioRegistro = table.Column<int>(type: "int", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRXVentasTransferencia", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BASCiudades");

            migrationBuilder.DropTable(
                name: "BASClasificadores");

            migrationBuilder.DropTable(
                name: "BASDirecciones");

            migrationBuilder.DropTable(
                name: "BASTipos");

            migrationBuilder.DropTable(
                name: "INIConfig");

            migrationBuilder.DropTable(
                name: "INIEmail");

            migrationBuilder.DropTable(
                name: "NEGClientes");

            migrationBuilder.DropTable(
                name: "NEGCuentaPagos");

            migrationBuilder.DropTable(
                name: "NEGEmpresas");

            migrationBuilder.DropTable(
                name: "NEGProductos");

            migrationBuilder.DropTable(
                name: "NEGSucursales");

            migrationBuilder.DropTable(
                name: "SEGUsuarios");

            migrationBuilder.DropTable(
                name: "TRXDetalleVentas");

            migrationBuilder.DropTable(
                name: "TRXVentas");

            migrationBuilder.DropTable(
                name: "TRXVentasCreditos");

            migrationBuilder.DropTable(
                name: "TRXVentasTransferencia");
        }
    }
}
