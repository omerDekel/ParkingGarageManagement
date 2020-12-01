using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using ParkingGarageManagement.Models;

namespace ParkingGarageManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GarageController : ControllerBase
    {
        private VehicleFactory vehicleFactory;

        private GarageModel garage = GarageModel.Instance;

        private void Init()
        {
            this.vehicleFactory = new VehicleFactory();
        }

        public GarageController()
        {
            Init();
        }

        [HttpPost]
        [Route("/checkin")]
        public string CheckIn([FromBody] CheckInInput input)
        {
            Vehicle vehicle = vehicleFactory.GetVehicle(input.VehicleType,input.LicensePlateID,int.Parse(input.Width)
                ,int.Parse(input.Height),int.Parse(input.Length));
            User user = new User(input.Name, input.Phone, input.LicensePlateID);
            Enum.TryParse(input.TicketType, out TicketRank rank);
            vehicle.DriverDetails = user;
            CheckInResult ticketInfo = garage.CheckIn(vehicle,rank);
            return System.Text.Json.JsonSerializer.Serialize(ticketInfo);
        }
        [HttpPost]
        [Route("/checkout/{LicensePlateID}")]
        public void CheckOut(string LicensePlateID)
        {
            garage.CheckOut(LicensePlateID);
        }
        [HttpGet]
        [Route("/getgaragestate")]
        public string GetGarageState()
        {
            string lotsStr = System.Text.Json.JsonSerializer.Serialize(garage.Lots);
            return lotsStr;
        }
    }
}
