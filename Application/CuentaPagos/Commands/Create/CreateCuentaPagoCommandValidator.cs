using FluentValidation;

namespace Application.CuentaPagos.Commands.Create;

public class CreateCuentaPagoCommandValidator : AbstractValidator<CreateCuentaPagoCommand>
{
    public CreateCuentaPagoCommandValidator()
    {
        RuleFor(v => v.NroCuentaPagos)
            .MaximumLength(35)
            .MinimumLength(8)
            .NotEmpty();

        RuleFor(v => v.BancoPagos)
            .MaximumLength(250)
            .MinimumLength(15)
            .NotEmpty();

        RuleFor(v => v.NombreTitular)
            .MaximumLength(30)
            .MinimumLength(5)
            .NotEmpty();

        RuleFor(v => v.DocumentoTitular)
            .MaximumLength(20)
            .MinimumLength(5)
            .NotEmpty();

        RuleFor(v => v.UrlQr)
            .NotEmpty();

        RuleFor(v => v.IdSucursal)
           .NotEmpty();

        RuleFor(v => v.Estado)
           .NotEmpty();

        RuleFor(v => v.IdUsuarioRegistro)
            .NotEmpty();
    }
}
