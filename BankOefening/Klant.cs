using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOefening
{
    public class Klant
    {
        //ATTRIBUTES
        private string voornaamValue;
        private string familienaamValue;

        //CONSTRUCTORS
        public Klant()
            : this("John", "Doe")
        { }

        public Klant(string vnaam, string fnaam)
        {
            Voornaam = vnaam;
            Familienaam = fnaam;
        }

        //DESTRUCTORS


        //PROPERTIES
        public string Voornaam
        {
            set
            {
                voornaamValue = value;
            }
            get
            {
                return voornaamValue;
            }
        }

        public string Familienaam
        {
            set
            {
                familienaamValue = value;
            }
            get
            {
                return familienaamValue;
            }
        }

        //METHODS
        public void Afbeelden()
        {
            Console.WriteLine("Naam klant: {0} {1}", Voornaam, Familienaam);
        }
    }
}
