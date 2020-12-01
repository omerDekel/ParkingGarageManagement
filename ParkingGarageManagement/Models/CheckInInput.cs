using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    public class CheckInInput
    {
        public string Name { get; set; }
        public string LicensePlateID { get; set; }
        public string Phone { get; set; }
        public string TicketType { get; set; }
        public string VehicleType { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }

    }
}
