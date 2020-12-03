using ParkingGarageManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagement.Logic
{
    /// <summary>
    /// This class is resposible of managing the parking garage.
    /// Using singleton design patterrn.
    /// </summary>
    public sealed class GarageManager
    {
        private static GarageManager instance = null;
        //array of entring vehicles 
        public List<Vehicle> EnteringVehicles { get; set; }
        //map between license plate id to its lot
        public Dictionary<string, Lot> OccupiedLots { get; set; }
        //map between ticket types and its rank
        public Dictionary<TicketRank, TicketType> TicketTypes { get; set; }
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
            EnteringVehicles = new List<Vehicle>();
            OccupiedLots = new Dictionary<string, Lot>();
            TicketTypes = new Dictionary<TicketRank, TicketType>();
            Lots = new Lot[60];
            for (int i = 0; i < Lots.Length; i++)
            {
                Lots[i] = new Lot(i + 1);
            }
            TicketTypes[TicketRank.VIP] = new VIPTicket(1, 10, 200, TicketRank.VIP);
            TicketTypes[TicketRank.Value] = new RestrictedTicket(11, 30, 100, TicketRank.Value, 2500, 2400, 5000, 72);
            TicketTypes[TicketRank.Regular] = new RestrictedTicket(31, 60, 50, TicketRank.Regular, 2000, 2000, 3000, 24);
            AddAllowedClassesToTickets();
        }
        public Lot[] Lots { get; set; }
        /// <summary>
        /// Adding the classes of vehicles that allowed for each ticket types
        /// </summary>
        private void AddAllowedClassesToTickets()
        {
            TicketTypes[TicketRank.VIP].AddClass(VehicleClass.A);
            TicketTypes[TicketRank.VIP].AddClass(VehicleClass.B);
            TicketTypes[TicketRank.VIP].AddClass(VehicleClass.C);
            TicketTypes[TicketRank.Value].AddClass(VehicleClass.A);
            TicketTypes[TicketRank.Value].AddClass(VehicleClass.B);
            TicketTypes[TicketRank.Regular].AddClass(VehicleClass.A);
        }



        /// <summary>
        /// Checking in the vehicle in parking garage.
        /// </summary>
        /// <param name="vehicle"> vehicle which wants to enter</param>
        /// <param name="rank">rank of the ticket type</param>
        /// <returns>information about the check in result</returns>
        public CheckInResult CheckIn(Vehicle vehicle, TicketRank rank)
        {
            int lot = -1;
            EnteringVehicles.Add(vehicle);
            TicketType ticketType = TicketTypes[rank];
            //if the ticket type is suitable to the vehicle's data.
            if (ticketType.IsVehicleSuitable(vehicle))
            {
                ParkVehicle(vehicle, ticketType, ref lot);
                return new CheckInResult(rank.ToString(), 0, true, lot, vehicle.VehicleName);
            }
            else
            {
                return FindMatchingTicket(vehicle, rank);
            }
        }
        /// <summary>
        /// checking out the vehicle
        /// </summary>
        /// <param name="licensePlateID">of the vehicle</param>
        /// <returns>true if check out succeed, else false</returns>
        public bool CheckOut(string licensePlateID)
        {
            if (OccupiedLots.ContainsKey(licensePlateID))
            {
                OccupiedLots[licensePlateID].freeLot();
                OccupiedLots.Remove(licensePlateID);
                return true;
            }
            return false;
        }
        /// <summary>
        /// find  where to park the vehicle according to the ticket type and where there's a free lot
        /// </summary>
        /// <param name="v">vehicle to parking</param>
        /// <param name="ticketType"></param>
        /// <returns></returns>
        public void ParkVehicle(Vehicle v, TicketType ticketType, ref int lot)
        {
            for (int i = ticketType.MinLotRange - 1; i < ticketType.MaxLotRange; i++)
            {
                Lot curLot = Lots[i];
                if (curLot.IsFree())
                {
                    curLot.ParkVehicle(v);
                    OccupiedLots[v.LicensePlate] = curLot;
                    lot = curLot.LotNumber;
                    break;
                }

            }
        }
        /// <summary>
        /// Finding a suitable ticket type and the cost differnce from original ticket type.
        /// Iterate the ticket types until finding a ticket type that validates the vehicle.
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        public CheckInResult FindMatchingTicket(Vehicle vehicle, TicketRank rank)
        {
            TicketType coresspondTicket = TicketTypes[rank];
            int initialCost = coresspondTicket.Price;
            // find corresponding ticketType 
            do
            {
                rank++;
                coresspondTicket = TicketTypes[rank];
            } while (TicketTypes.ContainsKey(rank) && !coresspondTicket.IsVehicleSuitable(vehicle));
            if (!TicketTypes.ContainsKey(rank))
            {
                rank = TicketRank.Undefined;
            }
            return new CheckInResult(rank.ToString(), coresspondTicket.Price - initialCost, false, -1, vehicle.VehicleName);
        }

    }
}
