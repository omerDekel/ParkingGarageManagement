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


        private GarageManager garage;

        private void Init()
        {
            garage = GarageManager.Instance;
        }

        public GarageController()
        {
            Init();
        }

        [HttpPost]
        [Route("/parking/checkin")]
        public string CheckIn([FromBody] CheckInInput input)
        {
            CheckInResult ticketInfo = garage.CheckIn(input);
            return System.Text.Json.JsonSerializer.Serialize(ticketInfo);
        }
        [HttpPost]
        [Route("/parking/checkout/{LicensePlateID}")]
        public void CheckOut(string LicensePlateID)
        {
            garage.CheckOut(LicensePlateID);
        }
        [HttpGet]
        [Route("/parking/getgaragestate")]
        public string GetGarageState()
        {
            string lotsStr = System.Text.Json.JsonSerializer.Serialize(garage.Lots);
            return lotsStr;
        }
    }
}
