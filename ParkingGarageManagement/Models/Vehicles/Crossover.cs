using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    /// <summary>
    /// crossover vehicle class
    /// </summary>
    public class Crossover: Vehicle
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="length"></param>
        public Crossover(string licensePlate, int width, int height, int length)
        {
            VehicleName = "Crossover";
            LicensePlate = licensePlate;
            Width = width;
            Height = height;
            Length = length;
            ClassType = VehicleClass.A;
        }
    }
}
