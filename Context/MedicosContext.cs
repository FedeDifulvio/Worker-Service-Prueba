using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WorkerServicePrueba.Entities;

namespace WorkerServicePrueba.Context
{
    public class MedicosContext : DbContext 
    {

        public MedicosContext(DbContextOptions options) : base(options) { }

        public DbSet<Medico> Medicos { get; set; }

    }
}
