using FluentValidation;

namespace Application.Clasificadores.Coomands.Create;

public class CreateClasificadorCommandValidator : AbstractValidator<CreateClasificadorCommand>
{
    public CreateClasificadorCommandValidator()
    {
        RuleFor(r => r.Descripcion)
        .Length(2, 200).NotEmpty().WithMessage("{PropertyName} es obligatorio,debe tener una longitud entre {MinLength} y {MaxLength} caractéres.");

        RuleFor(m => m.IdTipo)
        .NotEmpty();

        RuleFor(r => r.Estado)
        .NotNull();
    }
}
