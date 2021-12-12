using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WorkerServicePrueba.Context;
using WorkerServicePrueba.Interfaces;
using WorkerServicePrueba.services;

namespace WorkerServicePrueba
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        ILecturaMedico _medico;
      

        public Worker(ILogger<Worker> logger, ILecturaMedico medico)
        {
            _logger = logger;
            _medico = medico;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _medico.leer();

              
               
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }


      
    }
}
