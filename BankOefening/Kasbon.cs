using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOefening
{
    public class Kasbon : ISpaarmiddel
    {
        //CONSTRUCTORS
        public Kasbon(DateTime aankoop, decimal bedrag, int looptijd, decimal intrest, Klant eigenaar)
        {
            AankoopDatum = aankoop;
            Bedrag = bedrag;
            Looptijd = looptijd;
            Intrest = intrest;
            Eigenaar = eigenaar;
        }

        //ATTRIBUTES
        private DateTime aankoopDatumValue;
        private decimal bedragValue;
        private int looptijdValue;
        private decimal intrestValue;
        private Klant eigenaarValue;

        //PROPERTIES
        public DateTime AankoopDatum
        {
            set
            {
                if (value.Year < 1900)
                    throw new Exception("Ongeldige aankoopdatum, enkel data vanaf het jaar 1900 worden geaccepteerd.");
                aankoopDatumValue = value;
            }
            get { return aankoopDatumValue; }
        }

        public decimal Bedrag
        {
            set
            {
                if (value <= 0)
                    throw new Exception("Het bedrag kan niet negatief zijn.");
                bedragValue = value;
            }
            get { return bedragValue; }
        }

        public int Looptijd
        {
            set
            {
                if (value <= 0)
                    throw new Exception("De looptijd kan niet negatief zijn.");
                looptijdValue = value;
            }
            get { return looptijdValue; }
        }

        public decimal Intrest
        {
            set
            {
                if (value < 0)
                    throw new Exception("De intrest kan niet negatief zijn.");
                intrestValue = value;
            }
            get { return intrestValue; }
        }

        public Klant Eigenaar
        {
            set { eigenaarValue = value; }
            get { return eigenaarValue; }
        }

        //METHODS
        public void Afbeelden()
        {
            Console.WriteLine("Datum van aankoop {0}", AankoopDatum);
            Console.WriteLine("Bedrag: EUR {0}", Bedrag);
            Console.WriteLine("Looptijd: {0} jaar", Looptijd);
            Console.WriteLine("Intrest: {0}%", Intrest);
            Eigenaar.Afbeelden();
        }

        //DESTRUCTOR

    }
}
