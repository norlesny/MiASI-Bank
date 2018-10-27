namespace MiASI_Bank
{
    public class Lokata: ProduktBankowy
    {
        public RachunekBankowy Rachunek { get; set; }

        public Lokata(Kwota kwota)
        {
            Saldo = kwota;
        }

        public bool Zerwij()
        {
            throw new System.NotImplementedException();
        }
    }
}