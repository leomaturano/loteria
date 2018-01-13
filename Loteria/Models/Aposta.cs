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
        public Volante Numeros { get; set; }

        // Foreign Key
        [Required]
        public int ConcursoID { get; set; }
        // Navigation property
        public Concurso Concurso { get; set; }
    }
}