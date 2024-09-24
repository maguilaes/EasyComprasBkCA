using FluentValidation;

namespace Application.Clientes.Commands.Create;

public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
{
    public CreateClienteCommandValidator()
    {
        RuleFor(v => v.Documento)
            .MaximumLength(15)
            .MinimumLength(1)
            .NotEmpty();

        RuleFor(v => v.Nombres)
            .MaximumLength(30)
            .MinimumLength(3)
            .NotEmpty();

        RuleFor(v => v.Apellidos)
            .MaximumLength(30)
            .MinimumLength(5)
            .NotEmpty();

        RuleFor(v => v.Email)
            .EmailAddress().WithMessage("Debe ser una dirección de Email válida.");

        RuleFor(v => v.IdSucursal)
           .NotEmpty();

        RuleFor(v => v.Estado)
           .NotEmpty();
    }
}
