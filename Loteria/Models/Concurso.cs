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
        public Volante Numeros { get; set; }
    }
}