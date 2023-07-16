using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TruckBlazorWebAssembly.Server.Model;
using TruckBlazorWebAssembly.Shared;

namespace TruckBlazorWebAssembly.Server.Controllers
{
     //Install-Package SAPBlazorAlert

    [Route("[controller]")]
    [ApiController]
    public class TrucksController : ControllerBase
    {
        private readonly TruckContext? truckContext = null;

        public TrucksController(TruckContext _truckContext)
        {
            this.truckContext = _truckContext;
        }

        [HttpGet]
        public async Task<List<Truck>> GetAllTruck()
        {
            List<Truck> trucks = new List<Truck>();
            try
            {
                trucks = await truckContext.Trucks.OrderByDescending(f=> f.ID).ToListAsync();


                return trucks;
            }

            catch (Exception ex)
            {

                string mesage = ex.Message.ToString();
                return trucks;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Truck>> GetTruck(int id)
        {
            var truck = await truckContext.Trucks.SingleOrDefaultAsync(f => f.ID == id);
            if (truck == null)
            {
                return NotFound();
            }
            return truck;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResultMessage>> UpdateTruck(int id, TruckViewModel  truck)
        {
            var result = new ResultMessage();
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var lstTruck = await truckContext.Trucks.SingleOrDefaultAsync(f => f.ID == id);
                lstTruck.Title = truck.Title;
                lstTruck.Barcode = truck.Barcode;
                lstTruck.OwnerMobile = truck.OwnerMobile;
                lstTruck.OwnerName = truck.OwnerName;
                lstTruck.SmartCode = truck.SmartCode;
                lstTruck.Carryingweight = truck.Carryingweight;
                await truckContext.SaveChangesAsync();
                result.IsSuccess = true;
                return result;
            }
            catch (Exception)
            {

                result.IsSuccess = false;
                return result;
            }

        }

        [HttpPost]
        public async Task<ResultMessage> AddTruck(TruckViewModel truckViewModel)
        {
            var truck=new Truck();
            var result=new ResultMessage();
            try
            {
                truck.Title = truckViewModel.Title;
                truck.Barcode = truckViewModel.Barcode;
                truck.OwnerMobile = truckViewModel.OwnerMobile;
                truck.OwnerName = truckViewModel.OwnerName;
                truck.SmartCode = truckViewModel.SmartCode;
                truck.Carryingweight = truckViewModel.Carryingweight;
                truckContext.Trucks.Add(truck);
                await truckContext.SaveChangesAsync();
                result.IsSuccess=true;
                return result;
                ////////////////////return await Task.FromResult(result);
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                return result;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultMessage>> DeleteTruck(int  id)
        {
            var result=new ResultMessage();
            try
            {
                if (id==0)
                {
                    return BadRequest();
                }
                var delTruck = await truckContext.Trucks.FindAsync(id);
                if (delTruck != null)
                {
                    truckContext.Remove(delTruck);
                    await truckContext.SaveChangesAsync();
                    result.IsSuccess = true;
                    
                }
                return result;
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                return result;
            }
        }
    }
}
