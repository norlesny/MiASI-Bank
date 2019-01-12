namespace MiASI_Bank.Produkt
{
    public class NumerProduktu
    {
        public NumerProduktu()
        {
            Id = GetHashCode();
        }
        
        public int Id { get; }
    }
}