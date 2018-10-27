namespace MiASI_Bank
{
    public class Raportowanie
    {
        public Raport GenerujRaport(ProduktBankowy produkt)
        {
            var raport = new Raport();

            return raport;
        }
        public Raport GenerujRaport(IEnumerable<ProduktBankowy> produkty)
        {
            var raport = new Raport();

            foreach (var produkt in produkty)
            {
                raport.DodajWpis($"{produkt.Numer}:{produkt.Saldo}");
            }

            return raport;
        }
    }
}