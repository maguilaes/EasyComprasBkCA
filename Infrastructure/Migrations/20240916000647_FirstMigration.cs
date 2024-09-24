using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BASCiudades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ciudad = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    IdcPais = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BASCiudades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BASClasificadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    IdTipo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BASClasificadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BASDirecciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pais = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Ciudad = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Direccion = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CodigoPostal = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Coordenadas = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    IdRelacion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BASDirecciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BASTipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BASTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NEGClientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Documento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Nombres = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NombreCompleto = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IdSucursal = table.Column<int>(type: "integer", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    IdUsuarioRegistro = table.Column<int>(type: "integer", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdUsuarioModificacion = table.Column<int>(type: "integer", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEGClientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NEGEmpresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NitEmpresa = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    NombreEmpresa = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Telefono = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Leyenda = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    UrlLogo = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    NombreContacto = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    TelefonoContacto = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    IdcCategoria = table.Column<int>(type: "integer", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    Ubicacion = table.Column<bool>(type: "boolean", nullable: false),
                    Coordenadas = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IdUsuarioRegistro = table.Column<int>(type: "integer", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdUsuarioModificacion = table.Column<int>(type: "integer", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEGEmpresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NEGProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdSucursal = table.Column<int>(type: "integer", nullable: false),
                    IdcCategoria = table.Column<int>(type: "integer", nullable: false),
                    Codigo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NombreProducto = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    IdcMedida = table.Column<int>(type: "integer", nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "numeric", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "numeric", nullable: false),
                    UrlImagen = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    IdUsuarioRegistro = table.Column<int>(type: "integer", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdUsuarioModificacion = table.Column<int>(type: "integer", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEGProductos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NEGSucursales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdcCiudad = table.Column<int>(type: "integer", nullable: false),
                    NombreSucursal = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    IdEmpresa = table.Column<int>(type: "integer", nullable: false),
                    IdUsuarioRegistro = table.Column<int>(type: "integer", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdUsuarioModificacion = table.Column<int>(type: "integer", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEGSucursales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SEGUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreCompleto = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Clave = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    IdcRol = table.Column<int>(type: "integer", nullable: false),
                    IdEmpresa = table.Column<int>(type: "integer", nullable: false),
                    IdSucursal = table.Column<int>(type: "integer", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    IdUsuarioRegistro = table.Column<int>(type: "integer", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdUsuarioModificacion = table.Column<int>(type: "integer", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEGUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TRXDetalleVentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoProducto = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IdMedida = table.Column<int>(type: "integer", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "numeric", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    SubTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    IdVenta = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRXDetalleVentas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TRXVentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCliente = table.Column<int>(type: "integer", nullable: false),
                    Coordenadas = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    IdcFormaEntrega = table.Column<int>(type: "integer", nullable: false),
                    IdcFormaPago = table.Column<int>(type: "integer", nullable: false),
                    IdcEstadoPago = table.Column<int>(type: "integer", nullable: false),
                    IdcEstadoVenta = table.Column<int>(type: "integer", nullable: false),
                    IdSucursal = table.Column<int>(type: "integer", nullable: false),
                    IdUsuarioRegistro = table.Column<int>(type: "integer", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdUsuarioModificacion = table.Column<int>(type: "integer", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRXVentas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TRXVentasCredito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdcEstadoCredito = table.Column<int>(type: "integer", nullable: false),
                    DeudaInicial = table.Column<decimal>(type: "numeric", nullable: false),
                    MontoPagado = table.Column<decimal>(type: "numeric", nullable: false),
                    DeudaActual = table.Column<decimal>(type: "numeric", nullable: false),
                    IdVenta = table.Column<int>(type: "integer", nullable: false),
                    IdUsuarioRegistro = table.Column<int>(type: "integer", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdUsuarioModificacion = table.Column<int>(type: "integer", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRXVentasCredito", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BASCiudades");

            migrationBuilder.DropTable(
                name: "BASClasificadores");

            migrationBuilder.DropTable(
                name: "BASDirecciones");

            migrationBuilder.DropTable(
                name: "BASTipos");

            migrationBuilder.DropTable(
                name: "NEGClientes");

            migrationBuilder.DropTable(
                name: "NEGEmpresas");

            migrationBuilder.DropTable(
                name: "NEGProductos");

            migrationBuilder.DropTable(
                name: "NEGSucursales");

            migrationBuilder.DropTable(
                name: "SEGUsuarios");

            migrationBuilder.DropTable(
                name: "TRXDetalleVentas");

            migrationBuilder.DropTable(
                name: "TRXVentas");

            migrationBuilder.DropTable(
                name: "TRXVentasCredito");
        }
    }
}
