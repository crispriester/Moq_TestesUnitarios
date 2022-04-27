using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;
using Repository.Interfaces;
using Services.Services;
using Xunit;
using Repository.Entidades;
using Services.Dto;

namespace TesteUnitario
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

            _siteEcommerceRepository.Setup(x => x.GetCollection()).Returns(lista);

            var retorno = (List<RetornoDto>)_service.GetCollection().Item2;

            Assert.Equals(3, retorno.Count);
        }

        [Fact]
        public void GetCollection_Deve_Retornar_Erro()
        {
            Setup();

            var lista = new List<SiteEcommerceEntity>();

            _siteEcommerceRepository.Setup(x => x.GetCollection()).Returns(lista);

            var retorno = (MensagemRetornoDto)_service.GetCollection().Item2;

            Assert.Equals("Nenhum produto encontrado.", retorno.Mensagem);
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

            var retorno = (List<RetornoDto>)_service.Patch(It.IsAny<Guid>()).Item2;

            foreach (var item in retorno)
            {
                var result = lista.Find(x => x.Id == item.Id);

                Assert.Equals(result.Situacao, item.Situacao);
            }

            Assert.Equals(listaAtualizada.Count, retorno.Count);
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

            var retorno = (List<RetornoDto>)_service.Patch(It.IsAny<Guid>()).Item2;

            foreach (var item in retorno)
            {
                var result = lista.Find(x => x.Id == item.Id);

                Assert.Equals(result.Situacao, item.Situacao);
            }

            Assert.Equals("Produto não encontrado.", retorno);
        }
    }
}
