using FluentValidation;

namespace Application.Sucursales.Commands.Create;

public class CreateSucursalCommandValidator : AbstractValidator<CreateSucursalCommand>
{
    public CreateSucursalCommandValidator()
    {
        RuleFor(r => r.IdcCiudad)
            .NotEmpty()
            .WithName("IdcCiudad");

        RuleFor(r => r.NombreSucursal)
            .NotEmpty()
            .MaximumLength(100)
            .WithName("NombreSucursal");

        RuleFor(r => r.IdEmpresa)
            .NotEmpty()
            .WithName("IdEmpresa");

        RuleFor(r => r.Estado)
            .NotEmpty()
            .WithName("Estado");

        RuleFor(r => r.IdUsuarioRegistro)
            .NotEmpty();
    }
}
