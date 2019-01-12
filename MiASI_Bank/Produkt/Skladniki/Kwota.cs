namespace MiASI_Bank.Produkt
{
    public class Kwota
    {
        public Kwota()
        {
        }
        
        public Kwota(double wartosc)
        {
            Wartosc = wartosc;
        }
        
        public double Wartosc { get; set; }

        public override string ToString()
        {
            return Wartosc.ToString();
        }
    }
}