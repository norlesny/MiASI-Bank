using System;

namespace MiASI_Bank
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