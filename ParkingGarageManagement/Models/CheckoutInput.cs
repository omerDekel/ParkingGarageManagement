using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    public class CheckoutInput
    {
        [Required]
       public string LicensePlateID { get; set; }
    }
}
