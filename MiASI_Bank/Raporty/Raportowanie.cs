using System.Collections.Generic;
using MiASI_Bank.Produkt.Interfejsy;

namespace MiASI_Bank.Raporty
{
    public class Raportowanie
    {
        public Raport GenerujRaport(IProduktBankowy produkt)
        {
            var raport = new Raport();

            return raport;
        }
        public Raport GenerujRaport(IEnumerable<IProduktBankowy> produkty)
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