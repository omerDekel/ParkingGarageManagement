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
           
            MatchingTicketRank = ticketRank;
            Difference = difference;
            TicketTypeIsValid = ticketTypeIsValid;

        }
        public int Lot { get; set; }
        public bool TicketTypeIsValid { get; set; }
        public TicketRank MatchingTicketRank { get; set; }
        public int Difference { get; set; }
    }
}
