using Microsoft.OpenApi.Models;

namespace Kirala.com.WebAPI.Services
{
    public static class SwaggerService
    {
        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Kirala.com/WebAPI",
                    Version = "v1",
                    Contact = new OpenApiContact()
                    {
                        Name = "Bedirhan Uncu",
                        Email = "bdrhn35@outlook.com"
                    }
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                  });
            });
        }
    }
}
