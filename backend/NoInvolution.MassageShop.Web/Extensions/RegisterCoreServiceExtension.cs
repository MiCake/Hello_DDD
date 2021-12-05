using Microsoft.OpenApi.Models;
using System.Reflection;

namespace NoInvolution.MassageShop.Web
{
    public static class RegisterCoreServiceExtension
    {
        public static void AddAppCoreServices(this WebApplicationBuilder webBuilder)
        {
            // Swagger
            webBuilder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Calliope.Dream.Web", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Authorization format : Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new List<string>()
                    }
                });

                //var xfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xpath = Path.Combine(AppContext.BaseDirectory, xfile);
                //c.IncludeXmlComments(xpath);
            });

            // HttpClientFactory
            webBuilder.Services.AddHttpClient();
        }
    }
}
