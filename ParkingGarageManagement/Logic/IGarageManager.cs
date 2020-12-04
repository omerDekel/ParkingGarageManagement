using ParkingGarageManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Logic
{
    /// <summary>
    /// Interface of garage manager logic. 
    /// Supports check in a vehicle, check out and saving data regarding its lots.
    /// </summary>
    interface IGarageManager
    {
        public Lot[] Lots { get; set; }

        CheckInResult CheckIn(Vehicle vehicle, TicketRank rank, Driver driver);

        bool CheckOut(string licensePlateID);

    }
}
