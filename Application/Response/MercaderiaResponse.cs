﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class MercaderiaResponse
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public TipoMercaderiaResponse tipo { get; set; }
        public double precio { get; set; }
        public string ingredientes { get; set; }
        public string preparacion { get; set; }
        public string imagen { get; set; }
    }
}
