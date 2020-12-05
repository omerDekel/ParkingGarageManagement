using ParkingGarageManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Logic
{
    /// <summary>
    /// Vehicle factory. Using factory design pattern.
    /// </summary>
    public class VehicleFactory
    {
        /// <summary>
        /// Creating a vehicle object according to the input.
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
                case ("motorcycle"):
                    vehicle = new Motorcycle(licensePlate,width,height,length);
                    break;
                case ("private"):
                    vehicle = new PrivateVehicle(licensePlate, width, height, length);
                    break;
                case ("crossover"):
                    vehicle = new Crossover(licensePlate, width, height, length);
                    break;
                case ("van"):
                    vehicle = new Van(licensePlate, width, height, length);
                    break;
                case ("truck"):
                    vehicle = new Truck(licensePlate, width, height, length);
                    break;
                case ("suv"):
                    vehicle = new SUV(licensePlate, width, height, length);
                    break;
            }
            return vehicle;
        }
    }
}
