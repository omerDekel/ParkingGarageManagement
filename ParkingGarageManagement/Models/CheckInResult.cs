using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    public class CheckInResult
    {
        public CheckInResult(string ticketRank, int difference, bool ticketTypeIsValid,int lot,string vehicleType)
        {
           Lot = lot;
            MatchingTicketRank = ticketRank;
            DifferenceCost = difference;
            TicketTypeIsSuitable = ticketTypeIsValid;
            VehicleType = vehicleType;

        }
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
