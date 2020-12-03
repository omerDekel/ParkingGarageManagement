using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    /// <summary>
    /// details about the user .
    /// </summary>
    public class User
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="licensceIdPlate"></param>
        public User(string name, string phone, string licensceIdPlate)
        {
            Name = name;
            Phone = phone;
            LicensceIdPlate = licensceIdPlate;
        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string LicensceIdPlate { get; set; }
    }
}
