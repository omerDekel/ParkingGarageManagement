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
using ParkingGarageManagement.Logic;

namespace ParkingGarageManagement.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class GarageController : ControllerBase
    {
        const string errorMessage = "Error!";
        private VehicleFactory vehicleFactory;
        private GarageManager garage;

        private void Init()
        {
            vehicleFactory = new VehicleFactory();
            garage = GarageManager.Instance;
        }
        public GarageController()
        {
            Init();
        }

        [HttpPost]
        [Route("/checkin")]
        public string CheckIn([FromBody] CheckInInput input)
        {
            if (!input.InputisValid())
            {
                return errorMessage;
            }
            Vehicle vehicle = vehicleFactory.GetVehicle(input.VehicleType, input.LicensePlateID, int.Parse(input.Width)
               , int.Parse(input.Height), int.Parse(input.Length));
            //validate the rank and vehicle type
            bool rankIsValid = Enum.TryParse(input.TicketType, out TicketRank rank);
            if (vehicle == null || !rankIsValid)
            {
                return errorMessage;
            }
            User user = new User(input.Name, input.Phone, input.LicensePlateID);
            vehicle.DriverDetails = user;
            CheckInResult ticketInfo = garage.CheckIn(vehicle,rank);
            return System.Text.Json.JsonSerializer.Serialize(ticketInfo);
        }
        [HttpPost]
        [Route("/checkout/{LicensePlateID}")]
        public string CheckOut(string LicensePlateID)
        {
            if (garage.CheckOut(LicensePlateID))
            {
                return "Check out succeed";
            }
            else
            {
                return "Check Out failed.";
            }
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
