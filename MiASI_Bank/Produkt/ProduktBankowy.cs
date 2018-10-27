using System;

namespace MiASI_Bank
{
    public class ProduktBankowy
    {
        public string NumerRachunku { get; set; }
        public DateTime DataZalozenia { get; set; }
        public Kwota Saldo { get; set; }
        public Historia Historia { get; set; }
        public Odsetki Odsetki { get; set; }
    }
}