using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Loteria.Models
{
    public class Aposta
    {
        public int Id { get; set; }
        [Required]
        public DateTime DataHora { get; set; }
        [Required]
        public int Jogo1 { get; set; }
        [Required]
        public int Jogo2 { get; set; }
        [Required]
        public int Jogo3 { get; set; }
        [Required]
        public int Jogo4 { get; set; }
        [Required]
        public int Jogo5 { get; set; }
        [Required]
        public int Jogo6 { get; set; }

        // Foreign Key
        [Required]
        public int ConcursoID { get; set; }
        // Navigation property
        public Concurso Concurso { get; set; }
    }
}