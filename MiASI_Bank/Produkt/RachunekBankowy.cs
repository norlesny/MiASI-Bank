namespace MiASI_Bank
{
    public class RachunekBankowy: ProduktBankowy
    {
        public Debet Debet { get; set; }

        public bool Zamknij()
        {
            throw new System.NotImplementedException();
        }

        public bool DodajLokate(Kwota kwota)
        {
            throw new System.NotImplementedException();
        }
    }
}