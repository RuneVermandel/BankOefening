using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOefening
{
    public class BankBediende
    {
        //CONSTRUCTORS
        public BankBediende()
            : this("John", "Doe")
        { }

        public BankBediende(string voornaam, string naam)
        {
            Voornaam = voornaam;
            Naam = naam;
        }

        //ATTRIBUTES
        private string voornaamValue;
        private string naamValue;

        //PROPERTIES
        public string Voornaam
        {
            set { voornaamValue = value; }
            get { return voornaamValue; }
        }

        public string Naam
        {
            set { naamValue = value; }
            get { return naamValue; }
        }

        //METHODS
        public override string ToString()
        {
            return "Bankbediende " + Voornaam + ' ' + Naam;
        }

        public void ToonUittreksel(Rekening rek)
        {
            Console.WriteLine("Rekeningnummer: {0}", rek.Rekeningnummer);
            Console.WriteLine("Klant: {0}", rek.Eigenaar);
            Console.WriteLine("Vorig Saldo: EUR {0}", rek.VorigSaldo);
            Console.WriteLine("Bedrag van de transactie: EUR {0}", rek.Saldo - rek.VorigSaldo);
            Console.WriteLine("Nieuw Saldo: EUR {0}", rek.Saldo);
        }

        public void SaldoInHetRood(Rekening rek)
        {
            Console.WriteLine("Het saldo van uw rekening is ontoereikend. Het bedrag dat u wil afhalen overschrijdt uw huidig rekeningsaldo van EUR {0}", rek.Saldo);
        }

        //DESTRUCTORS
    }
}
