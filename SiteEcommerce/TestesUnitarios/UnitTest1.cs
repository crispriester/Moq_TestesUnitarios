using System;
using System.Collections.Generic;
using Moq;
using Repository.Entidades;
using Repository.Interfaces;
using Repository.Repositorios;
using Services.Dto;
using Services.Services;
using Xunit;

namespace TestesUnitarios
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
        
            _siteEcommerceRepository.Setup(x => x.Patch(It.IsAny<Guid>())).Returns(lista);
        
            var retorno = (List<RetornoDto>)_service.Patch(It.IsAny<Guid>()).Item2;

            foreach (var item in retorno)
            {
                var result = lista.Find(x => x.Id == item.Id);
            
                Assert.Equal(result.Situacao, item.Situacao);
            }

            Assert.Equal(listaAtualizada.Count, retorno.Count);
        }
    }
}