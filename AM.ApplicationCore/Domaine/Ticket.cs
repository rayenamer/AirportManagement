namespace AM.ApplicationCore.Domaine;

public class Ticket
{
    public int NumTicket { get; set; }
    public double Prix { get; set; }
    public string Siege { get; set; }
    public bool VIP { get; set; }

    // Foreign keys
    public int PassengerFk { get; set; }
    public int FlightFk { get; set; }

    // Navigation properties
    public Passenger Passenger { get; set; }
    public Flight Flight { get; set; }
}

