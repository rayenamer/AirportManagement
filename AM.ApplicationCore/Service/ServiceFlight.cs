using AM.ApplicationCore.Domaine;
using AM.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Service
{
    public class ServiceFlight : IServiceFlight
    {
                // List of flights
        public List<Flight> Flights { get; set; } = new List<Flight>();

        // 1️⃣ GetFlightDates using LINQ
        public List<DateTime> GetFlightDatesSimple(string destination)
        {
            var flightDates = from flight in Flights
                              where flight.Destination == destination
                              select flight.FlightDate;
            return flightDates.ToList();
        }
        public List<DateTime> GetFlightDates(string destination)
        {
            return Flights
                .Where(f => f.Destination == destination)
                .Select(f => f.FlightDate)
                .ToList();
        }

        // 2️⃣ ShowFlightDetails for a given plane
        public void ShowFlightDetailsSimple(Plane plane)
        {
            var planeFlights = from flight in Flights
                               where flight.Plane == plane
                               select flight;

            foreach (var flight in planeFlights)
            {
               Console.WriteLine(flight.Destination + " - " + flight.FlightDate.ToShortDateString());
            }
        }
        public void ShowFlightDetails(Plane plane)
        {
            var planeFlights = Flights
                .Where(f => f.Plane == plane)
                .ToList();

            foreach (var flight in planeFlights)
            {
                Console.WriteLine($"Flight to {flight.Destination} on {flight.FlightDate}");
            }
        }

        // 3️⃣ ProgrammedFlightNumber in 7 days from a start date
        public int ProgrammedFlightNumberSimple(DateTime startDate)
        {
            DateTime endDate = startDate.AddDays(7);
            var count = (from flight in Flights
                         where flight.FlightDate >= startDate && flight.FlightDate <= endDate
                         select flight).Count();
            return count;
        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            DateTime endDate = startDate.AddDays(7);
            return Flights.Count(f => f.FlightDate >= startDate && f.FlightDate <= endDate);
        }

        // 4️⃣ DurationAverage for a destination
        public double DurationAverage(string destination)
        {
            return Flights
                .Where(f => f.Destination == destination)
                .Select(f => f.EstimatedDuration)
                .DefaultIfEmpty(0)
                .Average();
        }

        // 5️⃣ OrderedDurationFlights
        public List<Flight> OrderedDurationFlights()
        {
            return Flights
                .OrderByDescending(f => f.EstimatedDuration)
                .ToList();
        }

        // 6️⃣ SeniorTravellers: top 3 oldest travellers in a flight
        /*public List<Traveller> SeniorTravellers(Flight flight)
        {
            return flight.Passengers
                .OfType<Traveller>()
                .OrderByDescending(t => t.Age)
                .Take(3)
                .ToList();
        }*/

        // 7️⃣ DestinationGroupedFlights
        public void DestinationGroupedFlights()
        {
            var grouped = Flights
                .GroupBy(f => f.Destination);

            foreach (var group in grouped)
            {
                Console.WriteLine($"Destination: {group.Key}");
                foreach (var flight in group)
                {
                    Console.WriteLine($"\tFlight on {flight.FlightDate}");
                }
            }
        }

        // Optional: filter flights by type or value
        public List<Flight> GetFlights(string filterType, string filterValue)
        {
            return filterType switch
            {
                "Destination" => Flights.Where(f => f.Destination == filterValue).ToList(),
                "FlightDate" when DateTime.TryParse(filterValue, out var date) => Flights.Where(f => f.FlightDate == date).ToList(),
                "EffectiveArrival" when DateTime.TryParse(filterValue, out var arrival) => Flights.Where(f => f.EffectiveArrival == arrival).ToList(),
                _ => throw new Exception("Type de filtre invalide !")
            };
        }

    }
}
