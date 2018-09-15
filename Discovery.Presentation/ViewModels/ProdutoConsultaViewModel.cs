using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discovery.Presentation.ViewModels
{
    public class ProdutoConsultaViewModel
    {
        public Guid Id { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
    }
}
