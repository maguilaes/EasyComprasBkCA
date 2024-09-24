using FluentValidation;

namespace Application.Empresas.Commands.Create;

public class CreateEmpresaCommandValidator : AbstractValidator<CreateEmpresaCommand>
{
    public CreateEmpresaCommandValidator()
    {
        RuleFor(r => r.NitEmpresa)
            .NotEmpty()
            .MaximumLength(20)
            .WithName("NitEmpresa");

        RuleFor(r => r.NombreEmpresa)
            .NotEmpty()
            .MaximumLength(50)
            .WithName("NombreEmpresa");

        RuleFor(v => v.Email)
            .EmailAddress().WithMessage("Debe ser una dirección de Email válida.");

        RuleFor(r => r.Leyenda)
            .NotEmpty()
            .MaximumLength(20)
            .WithName("NitEmpresa");

        RuleFor(r => r.NombreContacto)
            .NotEmpty()
            .MaximumLength(50)
            .WithName("NombreContacto");

        RuleFor(r => r.TelefonoContacto)
            .NotEmpty()
            .MaximumLength(20)
            .WithName("TelefonoContacto");

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
