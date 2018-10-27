namespace MiASI_Bank
{
    public class RachunekBankowy : ProduktBankowy
    {
        public Debet Debet { get; private set; }

        private IList<Lokata> _lokaty = new List<Lokata>();
        private IList<Kredyt> _kredyty = new List<Kredyt>();

        public bool Zamknij()
        {
            var result = true;

            if(Debet != null && Debet.Kwota > 0.0)
            {
                result = false;
            }else if (_kredyty.Any())
            {
                result = false;
            }else if(_lokaty.Any())
            {
                // Mo¿emy zamkn¹æ konto kiedy mamy otwarte lokaty??
                result = false;
            }

            return result;
        }

        public bool DodajLokate(Kwota kwota)
        {
            var result = false;

            if(Saldo.Wartosc >= kwota.Wartosc && WyplacGotowke(kwota))
            {
                _lokaty.Add(new Lokata(kwota));
                result = true;
            }

            return result;
        }

        public bool DodajKredyt(Kwota kwota)
        {
            var result = false;

            if (WplacGotowke(kwota))
            {
                _kredyty.Add(new Kredyt(kwota));
                result = true;
            }

            return result;
        }

        public bool DodajDebet(Kwota limit)
        {
            var result = false;

            if(Debet == null)
            {
                Debet = new Debet(limit);
                result = true;
            }

            return result;
        }

        public override bool WplacGotowke(Kwota kwota)
        {
            if(Debet != null)
            {
                if (Debet.Kwota.Wartosc >= kwota.Wartosc)
                {
                    Debet.Kwota.Wartosc -= kwota.Wartosc;
                }
                else
                {
                    var pozostalaWplata = kwota.Wartosc - Debet.Kwota.Wartosc;
                    Debet.Kwota.Wartosc = 0.0;

                    Saldo.Wartosc += pozostalaWplata;
                }
            }
            else
            {
                Saldo.Wartosc += kwota.Wartosc;
            }

            return true;
        }

        public override bool WyplacGotowke(Kwota kwota)
        {
            var result = false;

            if (Saldo.Wartosc >= kwota.Wartosc)
            {
                Saldo.Wartosc -= kwota.Wartosc;
                result = true;
            }
            else if(Debet != null && Saldo.Wartosc + DostepnyDebet >= kwota.Wartosc)
            {
                var debet = kwota.Wartosc - Saldo.Wartosc;
                Saldo.Wartosc = 0.0;

                Debet.Kwota.Wartosc += debet;

                result = true;
            }

            return result;
        }
    }
}