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
       
        public string LicensePlate { get; set; }
        public int LotNumber { get; set; }
        public bool IsFree()
        {
            return LicensePlate == "";
        }
        public void ParkVehicle(Vehicle vehicle)
        {
            LicensePlate = vehicle.LicensePlate;
        }
        public void freeLot()
        {
            LicensePlate = "";
        }
    }
}
