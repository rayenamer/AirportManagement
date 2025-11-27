using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Domaine;
using AM.ApplicationCore.Service;
using static AM.ApplicationCore.Domaine.Plane;
using AM.ApplicationCore.extensions;

Console.WriteLine("****************  Test service ********************");
ServiceFlight sf = new ServiceFlight();
sf.Flights = TestData.listFlights; // assuming TestData.listFlights is populated

// ---------------- GetFlightDates ----------------
Console.WriteLine("****************  Get flight dates to Paris ********************");
foreach (var date in sf.GetFlightDates("Paris"))
{
    Console.WriteLine(date.ToShortDateString());
}

// ---------------- ShowFlightDetails ----------------
Console.WriteLine("****************  Show Flight Details for a plane ********************");
var plane = sf.Flights[0].Plane; // example plane from the first flight
sf.ShowFlightDetails(plane);

// ---------------- ProgrammedFlightNumber ----------------
Console.WriteLine("****************  Programmed Flight Number ********************");
DateTime startDate = new DateTime(2024, 01, 01);
int flightCount = sf.ProgrammedFlightNumber(startDate);
Console.WriteLine($"Number of flights in 7 days from {startDate.ToShortDateString()}: {flightCount}");

// ---------------- DurationAverage ----------------
Console.WriteLine("****************  Average Duration to Paris ********************");
double avgDuration = sf.DurationAverage("Paris");
Console.WriteLine($"Average estimated duration to Paris: {avgDuration} hours");

// ---------------- OrderedDurationFlights ----------------
Console.WriteLine("****************  Flights ordered by duration ********************");
var orderedFlights = sf.OrderedDurationFlights();
foreach (var flight in orderedFlights)
{
    Console.WriteLine($"Flight to {flight.Destination}, Duration: {flight.EstimatedDuration}");
}

// ---------------- SeniorTravellers ----------------
Console.WriteLine("****************  Top 3 oldest travellers on first flight ********************");
//var topTravellers = sf.SeniorTravellers(sf.Flights[0]);
//foreach (var traveller in topTravellers)
//{
  //  Console.WriteLine($"{traveller.FirstName} {traveller.LastName}, Age: {traveller.Age}");
//}

// ---------------- DestinationGroupedFlights ----------------
Console.WriteLine("****************  Flights grouped by destination ********************");
sf.DestinationGroupedFlights();

// ---------------- Existing GetFlights tests ----------------
Console.WriteLine("****************  GetFlights Tests ********************");

// Test 1 : Destination = Paris
var res1 = sf.GetFlights("Destination", "Paris");
Console.WriteLine("Vols vers Paris : " + res1.Count);

// Test 2 : FlightDate = 01/01/2022
var res2 = sf.GetFlights("FlightDate", "01/01/2022");
Console.WriteLine("Flight Date : " + res2.Count);

// Test 3 : EffectiveArrival = 01/01/2022 17:10:10
var res3 = sf.GetFlights("EffectiveArrival", "01/01/2022 17:10:10");
Console.WriteLine("Effective d'Arrival : " + res3.Count);

Console.WriteLine("****************  Passenger Extension Method Test ********************");
Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
Passenger p1 = new Passenger { FirstName = "rayen", LastName = "ameur" };
Console.WriteLine("UpperFullName: " + p1.UpperFullName());
