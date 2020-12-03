using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    /// <summary>
    /// private vehicle class
    /// </summary>
    public class PrivateVehicle:Vehicle
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="length"></param>
        public PrivateVehicle(string licensePlate, int width, int height, int length)
        {
            VehicleName = "Private";
            LicensePlate = licensePlate;
            Width = width;
            Height = height;
            Length = length;
            ClassType = VehicleClass.A;
        }
    }
}
