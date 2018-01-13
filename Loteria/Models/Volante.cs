using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Loteria.Models
{
    public class Volante
    {
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
    }
}