using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class ComandaGetResponse
    {
        public Guid id { get; set; }
        public ICollection<MercaderiaGetResponse> mercaderias { get; set; }
        public FormaEntregaResponse formaEntrega { get; set; }  
        public double total { get; set; }
        public string fecha { get; set; }
    }
}
