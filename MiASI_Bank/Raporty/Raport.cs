using System.Text;

namespace MiASI_Bank.Raporty
{
    public class Raport
    {
        private StringBuilder _wpisy;

        public Raport()
        {
            _wpisy = new StringBuilder();
        }

        public void DodajWpis(string wpis)
        {
            _wpisy.AppendLine(wpis);
        }

        public override string ToString()
        {
            return _wpisy.ToString();
        }
    }
}