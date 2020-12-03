using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    /// <summary>
    ///this class holding the check in input fields.
    /// </summary>
    public class CheckoutInput
    {
        [Required]
       public string LicensePlateID { get; set; }
    }
}
