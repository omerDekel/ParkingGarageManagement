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
    /// <summary>
    /// garage api controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GarageController : ControllerBase
    {
        private GarageManager garage;
        /// <summary>
        /// initialize method
        /// </summary>
        private void Init()
        {
            garage = GarageManager.Instance;
        }
        /// <summary>
        /// constructor
        /// </summary>
        public GarageController()
        {
            
            Init();
        }
        /// <summary>
        /// Http post for checking in a vehicle.
        /// Validating the input and parsing it to the corresponding objects for garage manager checkIn.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string json of the result, bad request if input is invalid</returns>
        [HttpPost]
        [Route("checkin")]
        public string CheckIn([FromBody] CheckInInput input)
        {
          //getting the vehicle object according to its input
            Vehicle vehicle = VehicleFactory.GetVehicle(input.VehicleType, input.LicensePlateID, int.Parse(input.Width)
               , int.Parse(input.Height), int.Parse(input.Length));
            //validate the rank and vehicle type
            bool rankIsValid = Enum.TryParse(input.TicketType, out TicketRank rank);
            if (vehicle == null || !rankIsValid)
            {
                return ReturnBadRequest("Invalid Input");
            }
            User user = new User(input.Name, input.Phone, input.LicensePlateID);
            vehicle.DriverDetails = user;
            CheckInResult ticketInfo = garage.CheckIn(vehicle,rank);
            return System.Text.Json.JsonSerializer.Serialize(ticketInfo);
        }
        /// <summary>
        /// http post request for checking out a vehicle
        /// </summary>
        /// <param name="input">license plate of the vehicle</param>
        /// <returns> True if the check out succeed,else false</returns>
        [HttpPost]
        [Route("checkout")]
        public bool CheckOut([FromBody]CheckoutInput input)
        {
            return (garage.CheckOut(input.LicensePlateID));
        }
        /// <summary>
        /// http get request for the current state of the garage. 
        /// </summary>
        /// <returns>Each lot and occupying vehicle ID.</returns>
        [HttpGet]
        [Route("getgaragestate")]
        public string GetGarageState()
        {
            string lotsStr = System.Text.Json.JsonSerializer.Serialize(garage.Lots);
            return lotsStr;
        }
        /// <summary>
        /// returns result of error.
        /// </summary>
        /// <param name="comment">comment of the error</param>
        /// <returns>bad request result</returns>
        private string ReturnBadRequest(string comment)
        {
            return System.Text.Json.JsonSerializer.Serialize(BadRequest(comment));
        }
    }
}
