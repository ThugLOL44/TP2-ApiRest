using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class ComandaResponse
    {
        public Guid id { get; set; }
        public ICollection<ComandaMercaderiaResponse> mercaderias { get; set; }
        public FormaEntregaResponse formaEntrega { get; set; }
        public double total { get; set; }
        public string fecha { get; set; }

    }
}
