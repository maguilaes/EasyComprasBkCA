using Application.Productos.Commands.Create;
using FluentValidation;

namespace Application.Empresas.Commands.Create;

public class CreateProductoCommandValidator : AbstractValidator<CreateProductoCommand>
{
    public CreateProductoCommandValidator()
    {
        RuleFor(r => r.IdSucursal)
            .NotEmpty();

        RuleFor(r => r.IdcMedida)
            .NotEmpty();

        RuleFor(r => r.IdcCategoria)
            .NotEmpty();

        RuleFor(r => r.Codigo)
            .NotEmpty()
            .Length(6, 20)
            .WithName("{PropertyName} debe tener una longitud entre {MinLength} y {MaxLength} caractéres.");

        RuleFor(r => r.NombreProducto)
            .NotEmpty()
            .Length(2, 50)
            .WithName("{PropertyName} debe tener una longitud entre {MinLength} y {MaxLength} caractéres.");

        RuleFor(r => r.Descripcion)
            .NotEmpty()
            .Length(2, 250)
            .WithName("{PropertyName} debe tener una longitud entre {MinLength} y {MaxLength} caractéres.");

        RuleFor(r => r.Stock)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(r => r.PrecioCompra)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(r => r.PrecioVenta)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(r => r.Estado)
            .NotEmpty();

        RuleFor(r => r.IdUsuarioRegistro)
            .NotEmpty();
    }
}