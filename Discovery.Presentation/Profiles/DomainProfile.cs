using AutoMapper;
using Discovery.Entities;
using Discovery.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discovery.Presentation.Profiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            #region Entity to ViewModel

            CreateMap<Produto, ProdutoConsultaViewModel>()
                .ForMember(dest => dest.Total,
                            src => src.MapFrom(p => p.Preco * p.Quantidade));

            #endregion

            #region ViewModel to Entity

            CreateMap<ProdutoCadastroViewModel, Produto>();
            CreateMap<ProdutoEdicaoViewModel, Produto>();

            #endregion
        }
    }
}
