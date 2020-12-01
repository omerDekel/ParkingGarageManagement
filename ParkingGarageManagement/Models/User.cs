using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    public class User
    {
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
