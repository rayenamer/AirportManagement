using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domaine
{
    public enum PlaneType
    {
        Boing,
        Airbus,
    }
    public class Plane
     {
        //public Plane(int capacity, DateTime manuFactureDate, PlaneTypeEnum planeType)
        //{
        //    Capacity = capacity;
        //    ManuFactureDate = manuFactureDate;
        //    PlaneType = planeType;
        //}

        public int PlaneId { get; set;  }
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        
        public PlaneType PlaneType { get; set; }

        public ICollection<Flight> Flights { get; set; }

        public override string? ToString()
        {
            return "Capacity: " + Capacity + "Manu Facture Date: " + ManufactureDate;
        }
    }
}
