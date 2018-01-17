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
        public int Jogo1 { get { return jogo1; } set { jogo1 = validNumber(value); } }
        [Required]
        public int Jogo2 { get { return jogo2; } set { jogo2 = validNumber(value); } }
        [Required]
        public int Jogo3 { get { return jogo3; } set { jogo3 = validNumber(value); } }
        [Required]
        public int Jogo4 { get { return jogo4; } set { jogo4 = validNumber(value); } }
        [Required]
        public int Jogo5 { get { return jogo5; } set { jogo5 = validNumber(value); } }
        [Required]
        public int Jogo6 { get { return jogo6; } set { jogo6 = validNumber(value); } }

        // Foreign Key
        [Required]
        public int ConcursoID { get; set; }
        // Navigation property
        public Concurso Concurso { get; set; }


        private int jogo1;
        private int jogo2;
        private int jogo3;
        private int jogo4;
        private int jogo5;
        private int jogo6;
        private int validNumber(int n)
        {
            if (n < 1)
            {
                throw new ArgumentOutOfRangeException("valor menor que o mínimo.");
            }
            if (n > 60)
            {
                throw new ArgumentOutOfRangeException("valor maior que o máximo.");
            }
            if ( jogo1 == n )
            {
                throw new ArgumentException("valor repetido no jogo1.");
            }
            if (jogo2 == n)
            {
                throw new ArgumentException("valor repetido no jogo2.");
            }
            if (jogo3 == n)
            {
                throw new ArgumentException("valor repetido no jogo3.");
            }
            if (jogo4 == n)
            {
                throw new ArgumentException("valor repetido no jogo4.");
            }
            if (jogo5 == n)
            {
                throw new ArgumentException("valor repetido no jogo5.");
            }
            if (jogo6 == n)
            {
                throw new ArgumentException("valor repetido no jogo6.");
            }
            return n;
        }
    }
}