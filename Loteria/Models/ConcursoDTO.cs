using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.Models
{
    public class ConcursoDTO
    {
        public int Id { get; set; }
        public List<int> Sorteio { get; set; }

        public ConcursoDTO()
        {
            this.Sorteio = new List<int>();
        }

    }
}