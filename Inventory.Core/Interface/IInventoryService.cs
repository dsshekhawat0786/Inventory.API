﻿using Inventory.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Interface
{
    public interface IInventoryService
    {
        Task<InventoryDTO> GetAllInventory();
        Task<bool> CheckIfKernalsAvailable(int invId, int qty);
    }
}
