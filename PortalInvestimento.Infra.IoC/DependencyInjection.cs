using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortalInvestimento.Application.Interfaces;
using PortalInvestimento.Application.Mappings;
using PortalInvestimento.Application.Services;
using PortalInvestimento.Domain.Interfaces;
using PortalInvestimento.Infra.Data.Context;
using PortalInvestimento.Infra.Data.Repositories;

namespace PortalInvestimento.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IAtivoRepository, AtivoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();

            services.AddScoped<IAtivoService, AtivoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPortfolioService, PortfolioService>();
            services.AddScoped<ITransacaoService, TransacaoService>();

            services.AddAutoMapper(typeof(DTOMappingProfile));


            return services;
        }
    }
}
