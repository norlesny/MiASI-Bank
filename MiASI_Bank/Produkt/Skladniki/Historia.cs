using System.Collections.Generic;
using MiASI_Bank.Operacje;

namespace MiASI_Bank.Produkt
{
    public class Historia
    {
        public Historia()
        {
            Operacje = new List<Operacja>();    
        }
        
        public List<Operacja> Operacje { get; set; } 
    }
}