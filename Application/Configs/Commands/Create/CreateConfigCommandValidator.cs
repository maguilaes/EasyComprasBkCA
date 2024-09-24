using FluentValidation;

namespace Application.Configs.Commands.Create;

public class CreateConfigCommandValidator : AbstractValidator<CreateConfigCommand>
{
    public CreateConfigCommandValidator()
    {
        RuleFor(r => r.Recurso)
            .NotEmpty()
            .MaximumLength(200)
            .WithName("Recurso");

        RuleFor(r => r.Propiedad)
              .NotEmpty()
              .MaximumLength(150)
              .WithName("Propiedad");

        RuleFor(r => r.Valor)
            .NotEmpty()
            .MaximumLength(1000)
            .WithName("Valor");

        RuleFor(r => r.Estado)
            .NotEmpty();
    }
}
