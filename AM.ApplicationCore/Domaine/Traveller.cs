using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domaine
{
    public class Traveller : Passenger
    {
        public string Nationality { get; set; }
        public string HealthInformation { get; set; }

        public override void PassengerType()
        {
            Console.WriteLine("I'm a traveller");
        }
    }
}
