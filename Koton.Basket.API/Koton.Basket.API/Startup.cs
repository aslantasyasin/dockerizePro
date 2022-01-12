using Koton.Basket.API.RabbitMQ;
using Koton.Basket.API.Services.Log;
using Koton.Basket.API.Services.Product.Post;
using Koton.Basket.Common.Messages;
using Koton.Basket.Infrastructure.Core.Repositories;
using Koton.Basket.Infrastructure.Core.Repositories.Base;
using Koton.Basket.Infrastructure.Data;
using Koton.Basket.Infrastructure.Repositories;
using Koton.Basket.Infrastructure.Repositories.Base;
using Koton.Basket.Infrastructure.SeedData;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koton.Basket.API
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
            services.AddMassTransit(x => {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(Configuration["RabbitMqUrl"], "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");

                    });
                });
            });

            services.AddMassTransitHostedService();

            services.AddDbContext<BasketContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MsSQLConnection")));
            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Koton.Basket.API", Version = "v1" });
            });


            #region Service Dependencies
              services.AddScoped(typeof(IPostAction), typeof(PostAction));
            services.AddScoped(typeof(ILogAction), typeof(LogAction));
            #endregion

            #region Repository Dependencies

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
             services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            #endregion


            #region Queue Message Dependencies
            services.AddScoped(typeof(IRabbitMQMessagePublisher), typeof(RabbitMQMessagePublisher));
            #endregion
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Koton.Basket.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            InitializeDatabase(app);
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<BasketContext>();

                if (context != null && context.Database != null)
                {
                    context.Database.Migrate();
                }
            }
        }

    }
}
