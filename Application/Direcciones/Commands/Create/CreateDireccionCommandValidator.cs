using FluentValidation;

namespace Application.Direcciones.Commands.Create;

public class CreateDireccionCommandValidator : AbstractValidator<CreateDireccionCommand>
{
    public CreateDireccionCommandValidator()
    {
        RuleFor(r => r.IdcPais)
            .NotEmpty();
        RuleFor(r => r.IdcCiudad)
            .NotEmpty();
        RuleFor(r => r.Telefono)
            .MaximumLength(15)
            .WithName("Telefono");
        RuleFor(r => r.Direccion)
            .MaximumLength(150)
            .WithName("Dirección");
        RuleFor(r => r.CodigoPostal)
            .MaximumLength(10)
            .NotEmpty()
            .WithName("Codigo Postal");
        RuleFor(r => r.Coordenadas)
            .MaximumLength(500)
            .WithName("Coordenadas");
        RuleFor(r => r.Estado)
            .NotEmpty();
        RuleFor(r => r.IdRelacion)
            .NotEmpty();
    }
}
