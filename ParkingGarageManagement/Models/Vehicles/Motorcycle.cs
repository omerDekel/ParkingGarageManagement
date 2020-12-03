using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    /// <summary>
    /// motorcycle vehicle class
    /// </summary>
    public class Motorcycle: Vehicle
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="length"></param>
        public Motorcycle(string licensePlate, int width, int height, int length)
        {
            VehicleName = "Motorcycle";
            LicensePlate = licensePlate;
            Width = width;
            Height = height;
            Length = length;
            ClassType = VehicleClass.A;
        }
    }
}
