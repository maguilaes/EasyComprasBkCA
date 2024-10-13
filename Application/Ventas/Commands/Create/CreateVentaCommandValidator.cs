using FluentValidation;

namespace Application.Ventas.Commands.Create
{
    public class CreateVentaCommandValidator : AbstractValidator<CreateVentaCommand>
    {
        public CreateVentaCommandValidator()
        {
            RuleFor(v => v.IdCliente)
                .NotEmpty();

            RuleFor(v => v.IdSucursal)
                .NotEmpty();

            RuleFor(v => v.IdFormaEntrega)
                .NotEmpty();

            RuleFor(v => v.IdFormaPago)
                .NotEmpty();

            RuleFor(v => v.IdEstadoVenta)
               .NotEmpty();

            RuleFor(v => v.IdEstadoPago)
               .NotEmpty();
            RuleFor(v => v.Coordenadas)
               .NotEmpty();
        }
    }
}