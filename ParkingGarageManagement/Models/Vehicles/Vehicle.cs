using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    public abstract class Vehicle
    {
        private string licensePlate;
        private VehicleClass classType;
        private int width;
        private int height;
        private int length;
        private User driverDetails;
        public string VehicleName { get; set; }
        public string LicensePlate { get => licensePlate; set => licensePlate = value; }
        public VehicleClass ClassType { get => classType; set => classType = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public int Length { get => length; set => length = value; }
        public User DriverDetails { get => driverDetails; set => driverDetails = value; }
    }
}
