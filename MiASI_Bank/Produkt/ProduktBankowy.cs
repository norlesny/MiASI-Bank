using System;
using MiASI_Bank.Interesanci;
using MiASI_Bank.Interesanci.Interfejsy;
using MiASI_Bank.Produkt.Interfejsy;

namespace MiASI_Bank.Produkt
{
    public abstract class ProduktBankowy : IProduktBankowy
    {
        public NumerProduktu Numer { get; set; }
        public IWlasciciel Wlasciciel { get; set; }
        public DateTime DataZalozenia { get; set; }
        public Kwota Saldo { get; protected set; }
        public Historia Historia { get; set; }
        public Odsetki Odsetki { get; set; }
    }
}