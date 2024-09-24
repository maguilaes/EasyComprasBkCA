using Application.Usuarios.Commands.Create;
using FluentValidation;

namespace Application.Clientes.Commands.Create;

public class CreateUsuarioCommandValidator : AbstractValidator<CreateUsuarioCommand>
{
    public CreateUsuarioCommandValidator()
    {
        RuleFor(v => v.NombreCompleto)
            .MaximumLength(45)
            .MinimumLength(3)
            .NotEmpty();

        RuleFor(v => v.Email)
            .EmailAddress().WithMessage("Debe ser una dirección de Email válida.");

        RuleFor(r => r.Clave)
             .NotEmpty()
             .MaximumLength(10)
             .WithName("Clave");
        RuleFor(v => v.IdEmpresa)
           .NotEmpty();

        RuleFor(v => v.IdSucursal)
           .NotEmpty();

        RuleFor(v => v.IdUsuarioRegistro)
           .NotEmpty();

        RuleFor(v => v.Estado)
           .NotEmpty();
    }
}
