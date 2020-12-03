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
    //[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GarageController : ControllerBase
    {
        private GarageManager garage;

        private void Init()
        {
            garage = GarageManager.Instance;
        }
        public GarageController()
        {
            
            Init();
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("checkin")]
        public string CheckIn([FromBody] CheckInInput input)
        {
            /*if (!input.InputisValid())
            {
                return errorMessage;
            }*/
            Vehicle vehicle = VehicleFactory.GetVehicle(input.VehicleType, input.LicensePlateID, int.Parse(input.Width)
               , int.Parse(input.Height), int.Parse(input.Length));
            //validate the rank and vehicle type
            bool rankIsValid = Enum.TryParse(input.TicketType, out TicketRank rank);
            if (vehicle == null || !rankIsValid)
            {
                //return System.Text.Json.JsonSerializer.Serialize(BadRequest());
                return ReturnBadRequest("Invalid Input");
            }
            User user = new User(input.Name, input.Phone, input.LicensePlateID);
            vehicle.DriverDetails = user;
            CheckInResult ticketInfo = garage.CheckIn(vehicle,rank);
            return System.Text.Json.JsonSerializer.Serialize(ticketInfo);
        }
        [HttpPost]
        [Route("checkout")]
        public bool CheckOut([FromBody]CheckoutInput input)
        {
            return (garage.CheckOut(input.LicensePlateID));
        }
        [HttpGet]
        [Route("getgaragestate")]
        public string GetGarageState()
        {
            string lotsStr = System.Text.Json.JsonSerializer.Serialize(garage.Lots);
            return lotsStr;
        }
        private string ReturnBadRequest(string comment)
        {
            return System.Text.Json.JsonSerializer.Serialize(BadRequest(comment));
        }
    }
}
