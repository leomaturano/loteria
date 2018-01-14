using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Loteria.Models
{
    public class Concurso
    {
        public int Id { get; set; }
        public int Sorteio1 { get; set; }
        public int Sorteio2 { get; set; }
        public int Sorteio3 { get; set; }
        public int Sorteio4 { get; set; }
        public int Sorteio5 { get; set; }
        public int Sorteio6 { get; set; }
    }
}