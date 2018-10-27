namespace MiASI_Bank
{
    public class Lokata: ProduktBankowy
    {
        public RachunekBankowy Rachunek { get; set; }

        public bool Zerwij()
        {
            throw new System.NotImplementedException();
        }
    }
}