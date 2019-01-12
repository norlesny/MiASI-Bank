namespace MiASI_Bank.Produkt
{
    public class Debet
    {
        public Kwota Kwota { get; private set; }
        public Kwota Limit { get; }

        public Kwota DostepnyDebet => new Kwota { Wartosc = Limit.Wartosc - Kwota.Wartosc };

        public Debet(Kwota limit)
        {
            Limit = limit;
        }
    }
}