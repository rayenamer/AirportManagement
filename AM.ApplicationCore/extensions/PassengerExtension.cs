using System;
using AM.ApplicationCore.Domaine;

namespace AM.ApplicationCore.extensions;

public static class PassengerExtension
{
     public static string UpperFullName(this Passenger p)
        {
            if (p == null) return string.Empty;

            string firstName = char.ToUpper(p.FirstName[0]) + p.FirstName.Substring(1).ToLower();
            string lastName = char.ToUpper(p.LastName[0]) + p.LastName.Substring(1).ToLower();

            return $"{firstName} {lastName}";
        }
}
