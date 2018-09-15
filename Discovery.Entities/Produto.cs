using System;

namespace Discovery.Entities
{
    public class Produto : BaseEntity<Produto>
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        
    }
}
