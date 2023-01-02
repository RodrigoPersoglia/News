using AccesData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Presentation.Controllers.Extensiones
{
    public static class ServiceCollectionExtension
    {
        //public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddDbContext<NewsContext>(options =>
        //       options.UseSqlServer(configuration.GetConnectionString("NewsContext")) , ServiceLifetime.Transient
        //   );

        //    return services;
        //}

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<OpcionesPaginacion>(configuration.GetSection("Paginacion"));

            //services.Configure<SmtpConfiguraciones>(configuration.GetSection("SmtpConfiguraciones"));

            //services.Configure<EncryptionOptions>(configuration.GetSection("EncryptionOptions"));

            //services.Configure<ReCaptchaConfiguraciones>(configuration.GetSection("ReCaptcha"));

            //services.Configure<AfipConfiguraciones>(configuration.GetSection("AFIP"));

            //services.Configure<AfipConfiguraciones>(configuration.GetSection("JwtIssuerOptions"));

            return services;
        }

        //public static IServiceCollection AddServices(this IServiceCollection services)
        //{
        //    services.AddScoped<ISolicitudPermisoCuitServicio, SolicitudPermisoCuitServicio>();
        //    return services;
        //}

        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Factura Electronica API", Version = "v1" });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                doc.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}