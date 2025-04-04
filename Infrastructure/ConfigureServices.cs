﻿using Domain.Repository;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)

        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConectaBD") ??
                    throw new InvalidOperationException("connection string 'ConectaPostgres' not found '"))
            );

            services.AddTransient<ICiudadRepository, CiudadRepository>();
            services.AddTransient<ISucursalRepository, SucursalRepository>();
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IDireccionRepository, DireccionRepository>();
            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IVentaRepository, VentaRepository>();
            services.AddTransient<IDetVentaRepository, DetalleVentaRepository>();
            services.AddTransient<IVentaCreditoRepository, VentaCreditoRepository>();
            services.AddTransient<ITipoRepository, TipoRepository>();
            services.AddTransient<IClasificadorRepository, ClasificadorRepository>();
            services.AddTransient<IConfigRepository, ConfigRepository>();
            services.AddTransient<IEmailRepository, EmailRepository>();
            services.AddTransient<ICuentaPagoRepository, CuentaPagoRepository>();
            services.AddTransient<IVentaTransferenciaRepository, VentaTransferenciaRepository>();
            services.AddTransient<IHashService, HashService>();
            services.AddTransient<IFireBaseService, FireBaseService>();
            return services;

        }
    }
}
