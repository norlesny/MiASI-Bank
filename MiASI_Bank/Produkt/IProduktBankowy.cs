using System;

namespace MiASI_Bank
{
    public interface IProduktBankowy
    {
        NumerProduktu Numer { get; set; }
        IWlasciciel Wlasciciel { get; set; }
        DateTime DataZalozenia { get; set; }
        Kwota Saldo { get; }
        Historia Historia { get; set; }
        Odsetki Odsetki { get; set; }
    }
}