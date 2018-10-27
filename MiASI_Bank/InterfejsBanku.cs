using System;
using System.Collections.Generic;
using System.Text;

namespace MiASI_Bank
{
    public class InterfejsBanku
    {
        private IDictionary<string, Wlasciciel> wlasciciele = new Dictionary<string, Wlasciciel>();
        private IBank _bank;

        public InterfejsBanku(IBank bank)
        {
            _bank = bank;
        }

        public bool WykonajOperacje(params string[] args)
        {
            if(args.Length == 0)
            {
                return false;
            }

            switch (args[0])
            {
                case "zalozRachunek":
                    
                    break;

                default:
                    break;
            }

            return false;
        }

        private Wlasciciel GetOrCreateWlasciciel(string name)
        {
            Wlasciciel wlasciciel;

            if(!wlasciciele.TryGetValue(name, out wlasciciel))
            {
                wlasciciel = new Wlasciciel(name);
                wlasciciele.Add(name, wlasciciel);
            }

            return wlasciciel;
        }
    }
}
