using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    /// <summary>
    /// truck vehicle class
    /// </summary>
    public class Truck : Vehicle
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="length"></param>
        public Truck(string licensePlate, int width, int height, int length)
        {
            VehicleName = "Truck";
            LicensePlate = licensePlate;
            Width = width;
            Height = height;
            Length = length;
            ClassType = VehicleClass.C;
        }
}
}
