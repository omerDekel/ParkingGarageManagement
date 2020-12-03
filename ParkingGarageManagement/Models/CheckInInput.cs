using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    /// <summary>
    /// this class holding the check in input fields.
    /// </summary>
    public class CheckInInput
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LicensePlateID { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string TicketType { get; set; }
        [Required]
        public string VehicleType { get; set; }
        [Required]
        public string Height { get; set; }
        [Required]
        public string Width { get; set; }
        [Required]
        public string Length { get; set; }
    }
}
