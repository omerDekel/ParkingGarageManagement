using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    /// <summary>
    /// abstract class representing a vehicle .
    /// </summary>
    public abstract class Vehicle
    {
        public string VehicleName { get; set; }
        public string LicensePlate { get; set; }
        public VehicleClass ClassType { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public User DriverDetails { get; set; }
    }
}
