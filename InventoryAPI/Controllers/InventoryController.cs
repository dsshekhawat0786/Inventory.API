using Inventory.Core.Interface;
using Inventory.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {

        private readonly IInventoryService _inventory;
       
        public InventoryController(IInventoryService inventory)
        {
            this._inventory = inventory;
        }

        [HttpGet]
        public async Task<InventoryDTO> GetInventory()
        {
            return await _inventory.GetAllInventory();
        }

        [Route("{invId}/{qty}")]
        [HttpGet]
        public async Task<bool> CheckAvailableInventory(int invId, int qty)
        {
            return await _inventory.CheckIfKernalsAvailable(invId, qty);
        }
    }
}