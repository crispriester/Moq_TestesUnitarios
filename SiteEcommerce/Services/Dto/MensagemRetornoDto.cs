using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dto
{
    public class MensagemRetornoDto
    {
        public string Mensagem { get; set; }

        public MensagemRetornoDto(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}
