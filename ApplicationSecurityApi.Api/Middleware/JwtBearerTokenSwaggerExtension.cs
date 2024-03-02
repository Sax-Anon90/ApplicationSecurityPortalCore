using Microsoft.OpenApi.Models;

namespace ApplicationSecurityApi.Api.Middleware
{
    public static class JwtBearerTokenSwaggerExtension
    {
        public static IServiceCollection AddJwtBearerTokenSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Application Security Api Core",
                    Description = "This is the main Application Security Api core that deals with the Identity Access Management " +
                    "for all Software Applications that require Role and Identity Access Management",
                    Contact = new OpenApiContact
                    {
                        Name = "Sakhile olwethu Mkize",
                        Email = "olwethumkize15@gmail.com"
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Input your Bearer token in this format - Bearer {your token here} to access this API",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
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
            return services;
        }
    }
}
