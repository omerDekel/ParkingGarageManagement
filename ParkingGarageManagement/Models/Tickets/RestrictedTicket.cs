using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    /// <summary>
    /// restricted ticket type with time limit, and allowed dimensions.
    /// </summary>
    public class RestrictedTicket : TicketType
    {
        public RestrictedTicket(int minLotRange, int maxLotRange, int price, TicketRank rank,int allowedMaxHight
            , int alloweMaxWidth, int allowedMaxLength, int timeLimit): base(minLotRange,maxLotRange,price,rank)
        {
            
            AllowedMaxHight = allowedMaxHight;
            AlloweMaxWidth = alloweMaxWidth;
            AllowedMaxLength = allowedMaxLength;
            TimeLimit = timeLimit;
        }
        //properties.
        public int AllowedMaxHight { get; set; }
        public int AlloweMaxWidth { get; set; }
        public int AllowedMaxLength { get; set; }
        public int TimeLimit { get; set; }
        /// <summary>
        /// validate the vehicles according to the allowed dimensions.
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public override bool IsVehicleSuitable(Vehicle vehicle)
        {
            if(vehicle.Width>AlloweMaxWidth || vehicle.Height > AllowedMaxHight 
                || vehicle.Length > AllowedMaxLength)
            {
                return false;
            }
            return true;
        }
    }
}
