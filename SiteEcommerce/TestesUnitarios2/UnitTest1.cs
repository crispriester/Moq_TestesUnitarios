using System;
using System.Collections.Generic;
using Moq;
using Repository.Interfaces;
using Services.Services;
using Xunit;
using Repository.Entidades;
using Services.Dto;

namespace TestesUnitarios2
{
    public class UnitTest1
    {
        private Mock<ISiteEcommerceRepository> _siteEcommerceRepository;
        private SiteEcommerceService _service;

        private void Setup()
        {
            _siteEcommerceRepository = new Mock<ISiteEcommerceRepository>();
            _service = new SiteEcommerceService(_siteEcommerceRepository.Object);
        }

        [Fact]
        public void GetCollection_Deve_Retornar_Colecao()
        {
            Setup();

            var lista = new List<SiteEcommerceEntity>()
            {
                new SiteEcommerceEntity
                (
                    "Teclado Mecânico",
                    799.49,
                    true,
                    "./images/image01.png"
                ),
                new SiteEcommerceEntity
                (
                    "Tablet Samsung",
                    999.99,
                    true,
                    "./images/image02.png"
                ),
                new SiteEcommerceEntity
                (
                    "Air Pods",
                    1499.99,
                    true,
                    "./images/image03.png"
                )
            };

            //todo metodo q esteja no setup, deve ter um `virtual` no depois do public la no repository

            // saber quantas vezes o metodo foi chamado
            //_siteEcommerceRepository.Setup(x => x.GetCollection(), Times.Exactly(1)).Returns(lista);
            //                                                            .Once (mesma coisa que o exactly(1)
            //                                                            .Never

            _siteEcommerceRepository.Setup(x => x.GetCollection()).Returns(lista);

            var retorno = (List<RetornoDto>)_service.GetCollection().Item2;

            Assert.Equal(3, retorno.Count);
        }

        [Fact]
        public void GetCollection_Deve_Retornar_Erro()
        {
            Setup();

            var lista = new List<SiteEcommerceEntity>();

            _siteEcommerceRepository.Setup(x => x.GetCollection()).Returns(lista);

            var retorno = (MensagemRetornoDto)_service.GetCollection().Item2;

            Assert.Equal("Nenhum produto encontrado.", retorno.Mensagem);
        }

        [Fact]
        public void Patch_Deve_Atualizar_Lista_De_Objetos()
        {
            Setup();

            var lista = new List<SiteEcommerceEntity>()
            {
                new SiteEcommerceEntity
                (
                    "Teclado Mecânico",
                    799.49,
                    true,
                    "./images/image01.png"
                ),
                new SiteEcommerceEntity
                (
                    "Tablet Samsung",
                    999.99,
                    true,
                    "./images/image02.png"
                ),
                new SiteEcommerceEntity
                (
                    "Air Pods",
                    1499.99,
                    true,
                    "./images/image03.png"
                )
            };

            var listaAtualizada = new List<SiteEcommerceEntity>()
            {
                new SiteEcommerceEntity
                (
                    "Teclado Mecânico",
                    799.49,
                    true,
                    "./images/image01.png"
                ),
                new SiteEcommerceEntity
                (
                    "Tablet Samsung",
                    999.99,
                    false,
                    "./images/image02.png"
                ),
                new SiteEcommerceEntity
                (
                    "Air Pods",
                    1499.99,
                    true,
                    "./images/image03.png"
                )
            };

            _siteEcommerceRepository.Setup(x => x.GetCollection()).Returns(lista);

            var retorno = (List<RetornoDto>)_service.Patch(lista[1].Id).Item2;
            
            Assert.Equal(listaAtualizada.Count, retorno.Count);
            
            foreach (var item in retorno)
            {
                var result = listaAtualizada.Find(x => x.Descricao == item.Descricao);

                Assert.Equal(result.Situacao, item.Situacao);
            }
        }

        [Fact]
        public void Patch_Deve_GerarErro()
        {
            Setup();

            var lista = new List<SiteEcommerceEntity>()
            {
                //Vazia
            };

            _siteEcommerceRepository.Setup(x => x.GetCollection()).Returns(lista);

            var retorno = (MensagemRetornoDto)_service.Patch(It.IsAny<Guid>()).Item2;

            Assert.Equal("Produto não encontrado.", retorno.Mensagem);
        }
    }
}
