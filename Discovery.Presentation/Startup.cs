using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Discovery.Infra.Repository;
using Discovery.Presentation.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Discovery.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ProdutoRepository>();

            services.AddMvc();
            Mapper.Initialize(m => m.AddProfile<DomainProfile>());
            
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",
                new Info
                {
                    Title = "Projeto ASP.NET Core WEBAPI",
                    Version = "v1",
                    Description = "Aula de C# WEBDEVELOPER - COTi",
                    Contact = new Contact
                    {
                        Name = "Luiz Guilherme Bandeira",
                        Url = "https://github.com/arkanael",
                        Email = "arkanael@gmail.com"
                    }
                });              
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(s => 
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Pojeto ASP.NET CORE 2.0 WEB API");
            });
        }
    }
}