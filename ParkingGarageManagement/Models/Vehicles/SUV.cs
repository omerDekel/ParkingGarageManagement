using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    public class SUV : Vehicle
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="length"></param>
        public SUV(string licensePlate, int width, int height, int length)
        {
            VehicleName = "SUV";
            LicensePlate = licensePlate;
            Width = width;
            Height = height;
            Length = length;
            ClassType = VehicleClass.B;
        }
    }
}
