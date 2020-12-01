using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    public class CheckInResult
    {
        public CheckInResult(TicketRank ticketRank, int difference, bool ticketTypeIsValid,int lot)
        {
           Lot = lot;
            MatchingTicketRank = ticketRank;
            DifferenceCost = difference;
            TicketTypeIsValid = ticketTypeIsValid;

        }
        //the lot the vehicle parked in
        public int Lot { get; set; }
        //flag if the ticket type is suitable to vehicle's data
        public bool TicketTypeIsValid { get; set; }
        //the alternate suitable provided ticket 
        public TicketRank MatchingTicketRank { get; set; }
        //the difference cost between the ticket provided by the user to the suitable one
        public int DifferenceCost { get; set; }
    }
}
