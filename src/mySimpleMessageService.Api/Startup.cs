using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using mySimpleMessageService.Api.Configuration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using mySimpleMessageService.Api.Extensions;
using mySimpleMessageService.Application.Messages.Command;
using mySimpleMessageService.Application.Messages.Validators;
using mySimpleMessageService.Persistence;

namespace mySimpleMessageService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SimpleMessageServiceDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            services.AddMvc()
                    .AddFluentValidation(s =>
                    {
                        s.RegisterValidatorsFromAssemblyContaining<SendMessageCommandValidator>();
                        s.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                    });
            services.AddSwaggerDocument(settings =>
            {
                settings.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "mySimpleMessageService API Specification.";
                    document.Info.Description = "REST API for mySimpleMessageService.";
                };
            });
            services.AddMediatR(typeof(SendMessageCommand).GetTypeInfo().Assembly);
            services.RegisterSieveDependencies(Configuration);
           
            services.RegisterIoDependencies();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseOpenApi();

            app.ConfigureExceptionHandler();

            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
