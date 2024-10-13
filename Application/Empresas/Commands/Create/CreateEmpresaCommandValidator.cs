using FluentValidation;

namespace Application.Empresas.Commands.Create;

public class CreateEmpresaCommandValidator : AbstractValidator<CreateEmpresaCommand>
{
    public CreateEmpresaCommandValidator()
    {
        RuleFor(r => r.NitEmpresa)
            .NotEmpty()
            .Length(6,20)
            .WithName("{PropertyName} debe tener una longitud entre {MinLength} y {MaxLength} caractéres.");

        RuleFor(r => r.NombreEmpresa)
            .NotEmpty()
            .Length(3, 50)
            .WithName("{PropertyName} debe tener una longitud entre {MinLength} y {MaxLength} caractéres.");

        RuleFor(v => v.Email)
            .EmailAddress().WithMessage("Debe ser una dirección de Email válida.");

        RuleFor(r => r.Leyenda)
            .Length(6, 100)
            .WithName("{PropertyName} debe tener una longitud entre {MinLength} y {MaxLength} caractéres.");

        RuleFor(r => r.NombreContacto)
            .Length(6, 50)
            .WithName("{PropertyName} debe tener una longitud entre {MinLength} y {MaxLength} caractéres.");

        RuleFor(r => r.TelefonoContacto)
            .Length(6, 20)
            .WithName("{PropertyName} debe tener una longitud entre {MinLength} y {MaxLength} caractéres.");

        RuleFor(r => r.IdcCategoria)
            .NotEmpty();
        RuleFor(r => r.IdUsuarioRegistro)
            .NotEmpty();

        RuleFor(r => r.Ubicacion)
            .NotEmpty();

        RuleFor(r => r.Estado)
            .NotEmpty();
    }
}
