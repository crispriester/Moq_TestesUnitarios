using Repository.Interfaces;
using Repository.Entidades;
using System.Collections.Generic;

namespace Repository.Repositorios
{
    public class SiteEcommerceRepository : ISiteEcommerceRepository
    {
        public List<SiteEcommerceEntity> ListaProdutosEntity;

        public SiteEcommerceRepository()
        {
            ListaProdutosEntity = new List<SiteEcommerceEntity>()
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
                ),
                 new SiteEcommerceEntity
                (
                    "Cadeira Fortrek Gamer",
                    1479.99,
                    false,
                    "./images/image04.png"

                ),
                new SiteEcommerceEntity
                (
                    "Mouse Gamer Razer",
                    459.99,
                    false,
                    "./images/image05.png"
                ),
                new SiteEcommerceEntity
                (
                    "Nokia Tijolão",
                    399.99,
                    false,
                    "./images/image06.png"
                ),
                 new SiteEcommerceEntity
                (
                    "Microfone Gamer para jogos",
                    629.99,
                    false,
                    "./images/image07.png"
                ),
                 new SiteEcommerceEntity
                (
                    "Polystation",
                    199.99,
                    false,
                    "./images/image08.png"
                ),
                 new SiteEcommerceEntity
                (
                    "playstation 5",
                    4699.99,
                    false,
                    "./images/image09.png"
                ),
                new SiteEcommerceEntity
                (
                    "Monitor Gamer Full Hd 165Hz",
                    1399.99,
                    false,
                    "./images/image10.png"
                ),
            };
        }

        public virtual List<SiteEcommerceEntity> GetCollection()
        {
            return ListaProdutosEntity;
        }
    }
}
