using ParkingGarageManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Logic
{
    public class VehicleFactory
    {
        /// <summary>
        /// Creating a vehicle according to its data
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <param name="licensePlate"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="length"></param>
        /// <returns> a vehicle according to its data</returns>
        public static Vehicle GetVehicle(string vehicleType, string licensePlate, int width,int height,
         int length)
        {
            Vehicle vehicle=null;
            switch (vehicleType)
            {
                case ("Motorcycle"):
                    vehicle = new Motorcycle(licensePlate,width,height,length);
                    break;
                case ("Private"):
                    vehicle = new PrivateVehicle(licensePlate, width, height, length);
                    break;
                case ("Crossover"):
                    vehicle = new Crossover(licensePlate, width, height, length);
                    break;
                case ("Van"):
                    vehicle = new Van(licensePlate, width, height, length);
                    break;
                case ("Truck"):
                    vehicle = new Truck(licensePlate, width, height, length);
                    break;
                case ("SUV"):
                    vehicle = new SUV(licensePlate, width, height, length);
                    break;
            }
            return vehicle;
        }
    }
}
