using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOefening
{
    public abstract class Rekening : ISpaarmiddel
    {
        public delegate void Transactie(Rekening rek);

        //ATTRIBUTES
        private string rekeningnummerValue;
        private double saldoValue;
        private double vorigSaldoValue;
        private DateTime creatiedatumValue;
        private Klant eigenaarValue;

        //CONSTRUCTORS
        public Rekening()
            : this("BE00 0000 0000 0000", 0.0, DateTime.Today, new Klant())
        { }

        public Rekening(string rekeningnummer, double saldo, DateTime creatiedatum, Klant klant)
        {
            Rekeningnummer = rekeningnummer;
            Saldo = saldo;
            VorigSaldo = 0D;
            Creatiedatum = creatiedatum;
            Eigenaar = klant;
        }

        //DESTRUCTORS
        //NO DESTRUCTORS


        //PROPERTIES
        public string Rekeningnummer
        {
            get
            {
                return rekeningnummerValue;
            }
            set
            {
                string IBANNr = value;
                string IBANNrNoSpc = IBANNr.Replace(" ", "");
                string IBANNRControl = IBANNrNoSpc.Substring(0, 4);
                string IBANNrCCopy = IBANNrNoSpc.Insert(IBANNrNoSpc.Length, IBANNRControl);
                string IBANNrCMove = IBANNrCCopy.Substring(4, IBANNrNoSpc.Length);

                StringBuilder IBANNrNum = new StringBuilder("");

                for (int i = 0; i < IBANNrCMove.Length; i++)
                {
                    char wChar = IBANNrCMove.ElementAt(i);
                    int wCharInt = ((int)wChar) - 48;
                    if (wCharInt > 9)
                    {
                        wCharInt = wCharInt - 7;
                    }
                    IBANNrNum.Append(wCharInt);
                }

                ulong IBANNrNumLong = Convert.ToUInt64(IBANNrNum.ToString());

                if (IBANNrNumLong % 97 != 1)
                    throw new Exception("Ongeldig IBAN rekeningnummer.");
                rekeningnummerValue = value;
            }
        }

        public double Saldo
        {
            get
            {
                return saldoValue;
            }
            set
            {
                saldoValue = value;
            }
        }

        public double VorigSaldo
        {
            set { vorigSaldoValue = value; }
            get { return vorigSaldoValue; }
        }

        public DateTime Creatiedatum
        {
            get
            {
                return creatiedatumValue;
            }
            set
            {
                if (value.Year < 1900)
                    throw new Exception("Ongeldige creatiedatum, enkel data vanaf het jaar 1900 worden geaccepteerd.");
                creatiedatumValue = value;
            }
        }

        public Klant Eigenaar
        {
            set
            {
                eigenaarValue = value;
            }
            get
            {
                return eigenaarValue;
            }
        }

        //METHODS
        public virtual void Afbeelden()
        {
            Console.WriteLine("De eigenschappen van rekening met nummer {0}:", Rekeningnummer);
            if (Eigenaar != null)
            {
                Console.Write("Eigenaar: ");
                Eigenaar.Afbeelden();
            }
            Console.WriteLine("Saldo: EUR {0}", Saldo);
            Console.WriteLine("Creatiedatum: {0}", Creatiedatum);
        }

        public event Transactie Uittreksel;
        public event Transactie SaldoInHetRood;

        public void Storten(double bedrag)
        {
            VorigSaldo = Saldo;
            Saldo += bedrag;
            if (Saldo > VorigSaldo)
                if (Uittreksel != null)
                    Uittreksel(this);
        }

        public void Afhalen(double bedrag)
        {
            if (bedrag <= Saldo)
            {
                VorigSaldo = Saldo;
                Saldo -= bedrag;
                if (Uittreksel != null)
                    Uittreksel(this);
            }
            else
                if (SaldoInHetRood != null)
                    SaldoInHetRood(this);
        }
    }
}
