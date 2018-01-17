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
        public int Jogo1 { get { return jogo1; } set { jogo1 = numeroValido(value); ordenaNumeros(); } }
        [Required]
        public int Jogo2 { get { return jogo2; } set { jogo2 = numeroValido(value); ordenaNumeros(); } }
        [Required]
        public int Jogo3 { get { return jogo3; } set { jogo3 = numeroValido(value); ordenaNumeros(); } }
        [Required]
        public int Jogo4 { get { return jogo4; } set { jogo4 = numeroValido(value); ordenaNumeros(); } }
        [Required]
        public int Jogo5 { get { return jogo5; } set { jogo5 = numeroValido(value); ordenaNumeros(); } }
        [Required]
        public int Jogo6 { get { return jogo6; } set { jogo6 = numeroValido(value); ordenaNumeros(); } }

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
        private int numeroValido(int n)
        {
            if (n < 1)
            {
                throw new ArgumentOutOfRangeException("valor menor que o mínimo.");
            }
            if (n > 60)
            {
                throw new ArgumentOutOfRangeException("valor maior que o máximo.");
            }
            if (jogo1 == n)
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

        private void ordenaNumeros()
        {
            if (jogo1 == 0 || jogo2 == 0 || jogo3 == 0 || jogo4 == 0 || jogo5 == 0 || jogo6 == 0)
            {
                return;
            }
            int trocas, temp;
            do
            {
                // Ordena os números se todos são diferentes de zero (estão preenchidos);
                trocas = 0;
                if (jogo1 > jogo2)
                {
                    temp = jogo1;
                    jogo1 = Jogo2;
                    jogo2 = temp;
                    trocas++;
                }
                if (jogo2 > jogo3)
                {
                    temp = jogo2;
                    jogo2 = Jogo3;
                    jogo3 = temp;
                    trocas++;
                }
                if (jogo3 > jogo4)
                {
                    temp = jogo3;
                    jogo3 = Jogo4;
                    jogo4 = temp;
                    trocas++;
                }
                if (jogo4 > jogo5)
                {
                    temp = jogo4;
                    jogo4 = Jogo5;
                    jogo5 = temp;
                    trocas++;
                }
                if (jogo5 > jogo6)
                {
                    temp = jogo5;
                    jogo5 = Jogo6;
                    jogo6 = temp;
                    trocas++;
                }
            } while (trocas == 0);
            return;
        }

    }
}