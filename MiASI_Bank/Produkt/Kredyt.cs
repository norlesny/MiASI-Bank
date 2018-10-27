namespace MiASI_Bank
{
    public class Kredyt : ProduktBankowy
    {
        public RachunekBankowy Rachunek { get; set; }

        public Kredyt(Kwota kwota)
        {
            Saldo = kwota;
        }
    }
}