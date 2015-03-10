using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOefening
{
    class SpaarRekening : Rekening
    {
        //ATTRIBUTES
        private static double intrestValue;

        //CONSTRUCTORS
        public SpaarRekening()
            : base()
        { }

        public SpaarRekening(string rekeningnummer, double saldo, DateTime creatiedatum, Klant klant)
            : base(rekeningnummer, saldo, creatiedatum, klant)
        {
        }

        static SpaarRekening()
        {
            Intrest = 3.5;
        }

        //DESTRUCTORS


        //PROPERTIES
        public static double Intrest
        {
            get
            {
                return intrestValue;
            }
            set
            {
                if (value < 0)
                    throw new Exception("Ongeldige intrestwaarde, kan niet negatief zijn.");
                intrestValue = value;
            }
        }

        //METHODS
        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Deze spaarrekening heeft een intrestrate van {0}%.", Intrest);
        }
    }
}
