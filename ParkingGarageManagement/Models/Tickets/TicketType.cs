using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    public abstract class TicketType
    {
        private TicketRank rank;
        private int minLotRange;
        private int maxLotRange;
        /*private int allowedMaxHight;
        private int alloweMaxWidth;
        private int allowedMaxLength;*/
        private int price;

        protected TicketType(int minLotRange, int maxLotRange, int price, TicketRank rank)
        {
            Classes = new HashSet<VehicleClass>();
            MinLotRange = minLotRange;
            MaxLotRange = maxLotRange;
            Price = price;
            Rank = rank;
        }

        public int MinLotRange { get => minLotRange; set => minLotRange = value; }
        public int MaxLotRange { get => maxLotRange; set => maxLotRange = value; }
        public int Price { get => price; set => price = value; }
        public TicketRank Rank { get => rank; set => rank = value; }
        public HashSet<VehicleClass> Classes { get; set; }
        public void AddClass(VehicleClass vehicleClass)
        {
            Classes.Add(vehicleClass);
        }
        /*public int AllowedMaxHight { get => allowedMaxHight; set => allowedMaxHight = value; }
public int AlloweMaxWidth { get => alloweMaxWidth; set => alloweMaxWidth = value; }
public int AllowedMaxLength { get => allowedMaxLength; set => allowedMaxLength = value; }*/
        public abstract bool ticketValidate(Vehicle vehicle);
    }
}
