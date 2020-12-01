using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    public class RestrictedTicket : TicketType
    {
        private int allowedMaxHight;
        private int alloweMaxWidth;
        private int allowedMaxLength;
        private int timeLimit;

        public RestrictedTicket(int minLotRange, int maxLotRange, int price, TicketRank rank,int allowedMaxHight
            , int alloweMaxWidth, int allowedMaxLength, int timeLimit): base(minLotRange,maxLotRange,price,rank)
        {
            
            AllowedMaxHight = allowedMaxHight;
            AlloweMaxWidth = alloweMaxWidth;
            AllowedMaxLength = allowedMaxLength;
            TimeLimit = timeLimit;
        }

        public int AllowedMaxHight { get => allowedMaxHight; set => allowedMaxHight = value; }
        public int AlloweMaxWidth { get => alloweMaxWidth; set => alloweMaxWidth = value; }
        public int AllowedMaxLength { get => allowedMaxLength; set => allowedMaxLength = value; }
        public int TimeLimit { get => timeLimit; set => timeLimit = value; }

        public override bool ticketValidate(Vehicle vehicle)
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
