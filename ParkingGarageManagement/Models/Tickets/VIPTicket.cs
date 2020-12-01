using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    public class VIPTicket : TicketType
    {
        public VIPTicket(int minLotRange, int maxLotRange,int price, TicketRank rank) : base(minLotRange, maxLotRange, price, rank)
        {
            /*Classes.Add(VehicleClass.A);
            Classes.Add(VehicleClass.B);
            Classes.Add(VehicleClass.C);*/
            MinLotRange = minLotRange;
            MaxLotRange = maxLotRange;
            Rank = rank;
        }

        public override bool ticketValidate(Vehicle vehicle)
        {
            return true;
        }
    }
}
