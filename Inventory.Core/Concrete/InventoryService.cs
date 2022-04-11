using Inventory.Core.Interface;
using Inventory.Core.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Concret
{
    public class InventoryService : IInventoryService
    {
        string baseurl = "https://mocki.io/v1/0077e191-c3ae-47f6-bbbd-3b3b905e4a60";

        public async Task<InventoryDTO> GetAllInventory()
        {
            RestClient Client = new RestClient();
            var request = new RestRequest(baseurl, Method.Get);
            var res = await Client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<InventoryDTO>(Convert.ToString(res.Content));
        }
        public async Task<bool> CheckIfKernalsAvailable(int invId, int qty)
        {
            InventoryDTO inventoryResponse = await GetAllInventory();
            if (inventoryResponse != null)
            {
                int? totalQtyAvailable = inventoryResponse?.Inventory?.Where(x => x.id == invId).First().kernels;
                int? pendingReqInventory = inventoryResponse?.Requests?.Where(x => x.inventoryId == invId)
                        .GroupBy(x => invId)
                        .Select(x => x.Sum(a => Convert.ToInt32(a.requestedKernels))).Sum();
                int finalQty = (totalQtyAvailable.Value - pendingReqInventory.Value) - qty;
                if (finalQty >= 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
      
    }
}
