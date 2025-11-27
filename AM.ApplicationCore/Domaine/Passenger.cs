using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domaine
{
    public class Passenger
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportNumber { get; set; }
        public ICollection<Flight> Flights { get; set; }

        public override string? ToString()
        {
            return "First Name: " + FirstName + "Last Name: " + LastName + "Email: " + EmailAddress;
        }

        public bool CheckProfile( string firstName,  string lastName )
        {
            return this.FirstName == firstName && this.LastName == lastName; 

        }

        public bool CheckProfile(string firstName, string lastName, string emailaddress)
        {
            return this.FirstName == firstName && this.LastName == lastName && this.EmailAddress == emailaddress;

        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }
    }
}
