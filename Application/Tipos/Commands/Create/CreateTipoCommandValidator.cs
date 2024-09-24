using FluentValidation;

namespace Application.Tipos.Commands.Create
{
    public class CreateTipoCommandValidator : AbstractValidator<CreateTipoCommand>
    {
        public CreateTipoCommandValidator()
        {
            RuleFor(r => r.Descripcion)
            .Length(6, 200).NotEmpty().WithMessage("{PropertyName} es obligatorio,debe tener una longitud entre {MinLength} y {MaxLength} caractéres.");

            RuleFor(r => r.Estado)
            .NotNull();
        }
    }
}
