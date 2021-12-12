using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkerServicePrueba.Context;
using WorkerServicePrueba.Entities;
using WorkerServicePrueba.Interfaces;

namespace WorkerServicePrueba.services
{
    class LecturaMedico : ILecturaMedico
    {
        
        MedicosContext _context;

        public LecturaMedico( IServiceScopeFactory factory)
        {
            _context = factory.CreateScope().ServiceProvider.GetRequiredService<MedicosContext>();
        }
        


        public void leer()
        {
            List<Medico> listaMedicos = _context.Medicos.ToList();
            listaMedicos.ForEach(medico => Console.WriteLine(medico.Nombre + " " + medico.Apellido));

        }
    }
}
