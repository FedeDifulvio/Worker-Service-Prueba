using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkerServicePrueba.Context;
using WorkerServicePrueba.Interfaces;
using WorkerServicePrueba.services;

namespace WorkerServicePrueba
{
    public class Program
    {

       

        public static void Main(string[] args)
        {
             CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, builder) =>
            {
                builder
                   .AddJsonFile("appsettings.json")
                   .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json")
                   .AddEnvironmentVariables()
                   .Build();
            })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<ILecturaMedico, LecturaMedico>();
                    services.AddDbContext<MedicosContext>(opts => opts.UseSqlServer(hostContext.Configuration.GetConnectionString("ConnectionString")));
                    services.AddHostedService<Worker>();
                });
    }
}
