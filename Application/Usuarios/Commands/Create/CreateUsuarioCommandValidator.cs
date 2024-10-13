using Application.Usuarios.Commands.Create;
using FluentValidation;

namespace Application.Clientes.Commands.Create;

public class CreateUsuarioCommandValidator : AbstractValidator<CreateUsuarioCommand>
{
    public CreateUsuarioCommandValidator()
    {
        RuleFor(v => v.NombreCompleto)
            .NotEmpty()
            .Length(6, 80)
            .WithName("{PropertyName} debe tener una longitud entre {MinLength} y {MaxLength} caractéres.");

        RuleFor(v => v.Email)
            .EmailAddress().WithMessage("Debe ser una dirección de Email válida.");

        RuleFor(r => r.Clave)
             .NotEmpty()
             .Length(6, 300)
             .WithName("Clave");

        RuleFor(v => v.IdEmpresa)
           .NotEmpty();

        RuleFor(v => v.IdSucursal)
           .NotEmpty();

        RuleFor(v => v.IdcRol)
           .NotEmpty();

        //RuleFor(v => v.IdUsuarioRegistro)
        //   .NotEmpty();

        RuleFor(v => v.Estado)
           .NotEmpty();
    }
}
