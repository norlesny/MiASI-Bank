using System;
using MiASI_Bank.Interesanci;
using MiASI_Bank.Interesanci.Interfejsy;

namespace MiASI_Bank.Produkt.Interfejsy
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