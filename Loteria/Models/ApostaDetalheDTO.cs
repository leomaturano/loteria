using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.Models
{
    public class ApostaDetalheDTO
    {
        public int Id { get; set; }
        public int ConcursoID { get; set; }
        public DateTime DataHora { get; set; }
        public List<int> Jogo { get; set; }

        public ApostaDetalheDTO()
        {
            this.Jogo = new List<int>();
        }

    }
}