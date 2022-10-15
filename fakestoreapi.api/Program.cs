using fakestoreapi.api.Services;
using fakestoreapi.application;
using fakestoreapi.application.Common.Interfaces;
using fakestoreapi.infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle;
using fakestoreapi.rabbit;


namespace fakestoreapi.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
            builder.Services.AddScoped<IRabitMQProducer, RabitMQProducer>();
            builder.Services.AddInfrastructure(builder.Configuration);
           builder.Services.AddApplication();
            builder.Services.AddSwaggerGen();
            //services.AddAuthentication()
            //  .AddIdentityServerJwt();
            //services.AddAuthentication()

          //  builder.Services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();
 

            app.MapControllers();

            app.Run();
        }

   
    }
}
