using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Models
{
    public class Request
    {
        public int id { get; set; }
        public int inventoryId { get; set; }
        public int requestedKernels { get; set; }
    }

}
