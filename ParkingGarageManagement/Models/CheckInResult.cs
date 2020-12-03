using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    /// <summary>
    /// class representing the result of the checkIn
    /// </summary>
    public class CheckInResult
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="ticketRank"></param>
        /// <param name="difference"></param>
        /// <param name="ticketTypeIsValid"></param>
        /// <param name="lot"></param>
        /// <param name="vehicleType"></param>
        public CheckInResult(string ticketRank, int difference, bool ticketTypeIsValid, int lot, string vehicleType)
        {
            Lot = lot;
            MatchingTicketRank = ticketRank;
            DifferenceCost = difference;
            TicketTypeIsSuitable = ticketTypeIsValid;
            VehicleType = vehicleType;

        }
        //the type of the vehicle
        public string VehicleType { get; set; }
        //the lot the vehicle parked in
        public int Lot { get; set; }
        //flag if the ticket type is suitable to vehicle's data
        public bool TicketTypeIsSuitable { get; set; }
        //the alternate suitable provided ticket 
        public string MatchingTicketRank { get; set; }
        //the difference cost between the ticket provided by the user to the suitable one
        public int DifferenceCost { get; set; }
    }
}
