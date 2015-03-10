using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOefening
{
    class ZichtRekening : Rekening
    {
        //ATTRIBUTES
        private double maxKredietValue;

        //CONSTRUCTORS
        public ZichtRekening()
            : base()
        {
            MaxKrediet = 0.0;
        }

        public ZichtRekening(string rekeningnummer, double saldo, DateTime creatiedatum, double krediet, Klant klant)
            : base(rekeningnummer, saldo, creatiedatum, klant)
        {
            MaxKrediet = krediet;
        }

        //DESTRUCTORS


        //PROPERTIES
        public double MaxKrediet
        {
            get
            {
                return maxKredietValue;
            }
            set
            {
                if (value >= 0)
                    throw new Exception("Ongeldige waarde voor MaxKrediet. Waarde hoort negatief te zijn.");
                maxKredietValue = value;
            }
        }

        //METHODS
        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("De laagst toegestane balans is EUR {0}.", MaxKrediet);
        }
    }
}
