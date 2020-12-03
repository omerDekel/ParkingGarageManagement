using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    /// <summary>
    /// vip ticket class.
    /// </summary>
    public class VIPTicket : TicketType
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="minLotRange"></param>
        /// <param name="maxLotRange"></param>
        /// <param name="price"></param>
        /// <param name="rank"></param>
        public VIPTicket(int minLotRange, int maxLotRange,int price, TicketRank rank) : base(minLotRange, maxLotRange, price, rank)
        {
            MinLotRange = minLotRange;
            MaxLotRange = maxLotRange;
        }
        /// <summary>
        /// in vip ticket the are no limits
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>true</returns>
        public override bool IsVehicleSuitable(Vehicle vehicle)
        {
            return true;
        }
    }
}
