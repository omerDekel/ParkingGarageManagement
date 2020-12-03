using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    public class Lot
    {
        public Lot(int lotNum)
        {
            LotNumber = lotNum;
            LicensePlate = "";
        }
       // the license plate id of the parking vehicle (empty if the lot is free)
        public string LicensePlate { get; set; }
        //the number of the lot
        public int LotNumber { get; set; }
        /// <summary>
        /// checks if the lot is free.
        /// </summary>
        /// <returns></returns>
        public bool IsFree()
        {
            return LicensePlate == "";
        }
        /// <summary>
        /// </summary>
        /// <param name="vehicle">the vehicle we want to park in this lot</param>
        public void ParkVehicle(Vehicle vehicle)
        {
            LicensePlate = vehicle.LicensePlate;
        }
        /// <summary>
        /// free this lot.
        /// </summary>
        public void freeLot()
        {
            LicensePlate = "";
        }
    }
}
