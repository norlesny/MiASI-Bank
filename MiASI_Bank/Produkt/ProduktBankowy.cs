using System;

namespace MiASI_Bank
{
    public abstract class ProduktBankowy : IProduktBankowy
    {
        public NumerProduktu Numer { get; set; }
        public Wlasciciel Wlasciciel { get; set; }
        public DateTime DataZalozenia { get; set; }
        public Kwota Saldo { get; protected set; }
        public Historia Historia { get; set; }
        public Odsetki Odsetki { get; set; }
    }
}