using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    /// <summary>
    /// details about the driver .
    /// </summary>
    public class Driver
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        public Driver(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
