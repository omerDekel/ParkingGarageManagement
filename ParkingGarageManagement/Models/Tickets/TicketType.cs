using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Models
{
    /// <summary>
    /// abstract class representing ticket type
    /// </summary>
    public abstract class TicketType
    {
        /// <summary>
        /// constructor.
        /// </summary>
        /// <param name="minLotRange"></param>
        /// <param name="maxLotRange"></param>
        /// <param name="price"></param>
        /// <param name="rank"></param>
        protected TicketType(int minLotRange, int maxLotRange, int price, TicketRank rank)
        {
            Classes = new HashSet<VehicleClass>();
            MinLotRange = minLotRange;
            MaxLotRange = maxLotRange;
            Price = price;
            Rank = rank;
        }
        // the starting lot number of the ticket's range
        public int MinLotRange { get; set; }
        //the ending lot number of the ticket's range
        public int MaxLotRange { get; set; }
        // the price of the ticket
        public int Price { get; set; }
        //the type of the ticket
        public TicketRank Rank { get; set; }
        //allowed vehicle classes to this ticket type 
        public HashSet<VehicleClass> Classes { get; set; }
        /// <summary>
        /// adding allowed vehicle class.
        /// </summary>
        /// <param name="vehicleClass"></param>
        public void AddClass(VehicleClass vehicleClass)
        {
            Classes.Add(vehicleClass);
        }
        /// <summary>
        /// validate if the vehicle is suitable to this ticket type.
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>true if the vehicle is suitable to the ticket, else false</returns>
        public abstract bool IsVehicleSuitable(Vehicle vehicle);
    }
}
