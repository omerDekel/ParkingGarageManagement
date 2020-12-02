using ParkingGarageManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Logic
{
    public sealed class GarageManager
    {
        private VehicleFactory vehicleFactory;
        private static GarageManager instance = null;
        //map between license plate id to their lot
        private Dictionary<string, Lot> occupiedLots ;
        //
        private Lot[] lots;
        //saving data regarding etering vehicles in memory
        private List<Vehicle> enteringVehicles;
        private Dictionary<TicketRank, TicketType> ticketTypes;
        public static GarageManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GarageManager();
                }
                return instance;

            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        private GarageManager()
        {
            this.vehicleFactory = new VehicleFactory();
            enteringVehicles = new List<Vehicle>();
            occupiedLots = new Dictionary<string, Lot>();
            ticketTypes = new Dictionary<TicketRank, TicketType>();
            lots = new Lot[60];
            for (int i = 0; i < lots.Length; i++)
            {
                lots[i] = new Lot(i + 1);
            }
            ticketTypes[TicketRank.VIP] = new VIPTicket(1, 10, 200, TicketRank.VIP);
            ticketTypes[TicketRank.Value] = new RestrictedTicket(11, 30, 100, TicketRank.Value, 2500, 2400, 5000, 72);
            ticketTypes[TicketRank.Regular] = new RestrictedTicket(31, 60, 50, TicketRank.Regular, 2000, 2000, 3000, 24);
            AddAllowedClassesToTickets();
        }
        /// <summary>
        /// Adding the classes of vehicles that allowed for each ticket types
        /// </summary>
        private void AddAllowedClassesToTickets()
        {
            ticketTypes[TicketRank.VIP].AddClass(VehicleClass.A);
            ticketTypes[TicketRank.VIP].AddClass(VehicleClass.B);
            ticketTypes[TicketRank.VIP].AddClass(VehicleClass.C);
            ticketTypes[TicketRank.Value].AddClass(VehicleClass.A);
            ticketTypes[TicketRank.Value].AddClass(VehicleClass.B);
            ticketTypes[TicketRank.Regular].AddClass(VehicleClass.A);
        }
        
        public Lot[] Lots { get => lots; set => lots = value; }
        public List<Vehicle> EnteringVehicles { get => enteringVehicles; set => enteringVehicles = value; }
        /// <summary>
        /// Checking in the vehicle in parking garage.
        /// </summary>
        /// <param name="vehicle"> vehicle which wants to enter</param>
        /// <param name="rank">rank of the ticket type</param>
        /// <returns>information about the check in result</returns>
        public CheckInResult CheckIn(Vehicle vehicle,TicketRank rank)
        {            
            int  lot = -1;
            enteringVehicles.Add(vehicle);
            TicketType ticketType = ticketTypes[rank];
            //if the ticket type is suitable to the vehicle's data.
            if (ticketType.ticketValidate(vehicle))
            {
                ParkVehicle(vehicle, ticketType, ref lot);
                return new CheckInResult(rank.ToString(), 0, true, lot,vehicle.VehicleName);
            }
            else
            {
                return FindMatchingTicket(vehicle, rank);
            }
        }
        public bool CheckOut(string licensePlateID)
        {
            if (occupiedLots.ContainsKey(licensePlateID))
            {
                occupiedLots[licensePlateID].freeLot();
                occupiedLots.Remove(licensePlateID);
                return true;
            }
            return false;
        }
        /// <summary>
        /// /find  where to park the vehicle according to its type and where there's a free lot
        /// </summary>
        /// <param name="v"></param>
        /// <param name="ticketType"></param>
        /// <returns></returns>
        public void ParkVehicle(Vehicle v, TicketType ticketType,ref int  lot)
        {
            for (int i = ticketType.MinLotRange - 1; i < ticketType.MaxLotRange; i++)
            {
                Lot curLot = Lots[i];
                if (curLot.IsFree())
                {
                    curLot.ParkVehicle(v);
                    occupiedLots[v.LicensePlate] = curLot;
                    lot = curLot.LotNumber;
                    break;
                }

            }
        }
        /// <summary>
        /// Finding a suitable ticket type and the cost differnce from original ticket type.
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        public CheckInResult FindMatchingTicket(Vehicle vehicle, TicketRank rank)
        {
            TicketType coresspondTicket = ticketTypes[rank];
            //bool found = false;
            int initialCost = coresspondTicket.Price;
            // find corresponding ticketType
            do
            {
                rank++;
                coresspondTicket = ticketTypes[rank];
            } while (ticketTypes.ContainsKey(rank) && !coresspondTicket.ticketValidate(vehicle));
            if (!ticketTypes.ContainsKey(rank))
            {
                rank = TicketRank.Undefined;
            }
            return new CheckInResult(rank.ToString(), coresspondTicket.Price - initialCost, false,-1,vehicle.VehicleName);
        }

    }
}
