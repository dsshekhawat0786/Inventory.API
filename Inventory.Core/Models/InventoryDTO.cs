using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Models
{
    public class InventoryDTO
    {

        public List<Inventory> Inventory { get; set; }
        public List<Request> Requests { get; set; }

    }
}
