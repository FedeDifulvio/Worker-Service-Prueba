﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerServicePrueba.Entities
{
    public class Medico
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Legajo { get; set; }

        public bool Estado { get; set; }

    }
}
