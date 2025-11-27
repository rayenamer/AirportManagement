using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domaine
{
    public class Staff : Passenger
    {
        public DateTime EmployementDate { get; set; }
        public float Salary { get; set; }
        public string Function { get; set; }

        public override void PassengerType()
        {
            base.PassengerType();
        }
    }
}
