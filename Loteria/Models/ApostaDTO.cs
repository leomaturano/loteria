using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.Models
{
    public class ApostaDTO
    {
//        public DateTime DataHora { get; set; }
        public int ConcursoID { get; set; }
        public List<int> Jogo { get; set; }

        public ApostaDTO()
        {
            this.Jogo = new List<int>();
        }
    }
}