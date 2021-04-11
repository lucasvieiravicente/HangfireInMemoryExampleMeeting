using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace ExemploInMemoryMeetingHangfire
{
    public static class StartupConfig
    {
        public static void ConfigurarServicos(this IServiceCollection services)
        {
            AdicionarSwaggerGenInfo(services);
            AdicionarHangfire(services);
        }

        public static void ConfigurarSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HangfireMeeting API v1");
            });
        }

        public static void UsarHangfire(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }

        private static void AdicionarSwaggerGenInfo(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "HangfireInMemoryMeeting API",
                    Description = "Api to exemplify the using of Hangfire",
                    Contact = new OpenApiContact
                    {
                        Name = "Lucas V. Vicente - LVI",
                        Email = "lucas.vicente@iteris.com.br",
                        Url = new Uri("https://white-moss-0cf7e1e0f.azurestaticapps.net/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://github.com/lucasvieiravicente/HangfireInMemoryExampleMeeting/blob/main/LICENSE")
                    },
                });
            });
        }

        private static void AdicionarHangfire(IServiceCollection services)
        {
            services.AddHangfire(hangfireConfig => hangfireConfig
                                                            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                                                            .UseSimpleAssemblyNameTypeSerializer()
                                                            .UseRecommendedSerializerSettings()
                                                            .UseMemoryStorage());

            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 0 });
        }
    }
}
