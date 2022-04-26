using Services.Interfaces;
using Services.Dto;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Services.Services
{
    public class SiteEcommerceService : ISiteEcommerceService
    {
        private readonly ISiteEcommerceRepository _siteEcommerceRepository;

        public SiteEcommerceService(ISiteEcommerceRepository siteEcommerceRepository)
        {
            _siteEcommerceRepository = siteEcommerceRepository;
        }

        public (int, object) Patch(Guid id)
        {
            var listaEntidade = _siteEcommerceRepository.Patch(id);

            if (!listaEntidade.Any())
            {
                return ((int)EnumRetornoHttp.NotFound, new MensagemRetornoDto("Produto não encontrado."));
            }

            List<RetornoDto> listaRetornoDto = new List<RetornoDto>();

            foreach (var item in listaEntidade)
            {
                listaRetornoDto.Add(RetornoDto.DeSiteEcommerceEntityParaRetornoDto(item));
            }

            return ((int)EnumRetornoHttp.Ok, listaRetornoDto);
        }

        public (int, object) GetCollection()
        {
            
            var listaEntidade = _siteEcommerceRepository.GetCollection();

            if (!listaEntidade.Any())
            {
                return ((int)EnumRetornoHttp.NotFound, new MensagemRetornoDto("Nenhum produto encontrado."));
            }

            List<RetornoDto> listaRetornoDto = new List<RetornoDto>();

            foreach (var item in listaEntidade)
            {
                listaRetornoDto.Add(RetornoDto.DeSiteEcommerceEntityParaRetornoDto(item));
            }

            return ((int)EnumRetornoHttp.Ok, listaRetornoDto);
        }

    }
}
