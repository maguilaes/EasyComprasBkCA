using Application.Ciudades.Commands.Create;
using FluentValidation;

namespace Application.Empresas.Commands.Create;

public class CreateCiudadCommandValidator : AbstractValidator<CreateCiudadCommand>
{
    public CreateCiudadCommandValidator()
    {
        RuleFor(r => r.Ciudad)
            .NotEmpty()
            .MaximumLength(30)
            .WithName("Ciudad");

        RuleFor(r => r.IdcPais)
            .NotEmpty();       

        RuleFor(r => r.Estado)
            .NotEmpty();
    }
}
