using System;

namespace Repository.Entidades
{
    public class SiteEcommerceEntity : BaseEntity
    {
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public bool Situacao { get; set; }
        public string Imagem { get; set; }

        public SiteEcommerceEntity(string descricao, double valor, bool situacao, string imagem)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Valor = valor;
            Situacao = situacao;
            Imagem = imagem;
        }
    }
}
