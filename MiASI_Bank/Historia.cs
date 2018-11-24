using System.Collections.Generic;

namespace MiASI_Bank
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