using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class MercaderiaRequest
    {
        public string nombre { get; set; }
        public int tipo { get; set; }
        public double precio { get; set; }
        public string ingredientes { get; set; }
        public string preparacion { get; set; }
        public string imagen { get; set; }
    }
}
