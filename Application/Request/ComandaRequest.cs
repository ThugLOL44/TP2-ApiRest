using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class ComandaRequest
    {
        public ICollection<int> mercaderias { get; set; }
        public int formaEntrega { get; set; }
    }
}
