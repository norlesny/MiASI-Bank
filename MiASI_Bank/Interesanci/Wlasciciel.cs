using MiASI_Bank.Interesanci.Interfejsy;

namespace MiASI_Bank.Interesanci
{
	public class Wlasciciel : IWlasciciel
	{
		public string Name { get; }
		public int Id { get; }

		private static int idCounter = 1;
		
		public Wlasciciel(string name)
		{
			Name = name;
			Id = idCounter++;
		}
	}
}