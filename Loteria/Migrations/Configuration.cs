namespace Loteria.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Loteria.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Loteria.Models.LoteriaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Loteria.Models.LoteriaContext context)
        {
            context.Concursos.AddOrUpdate(c => c.Id,
                new Concurso() { Id = 1, Sorteio1 = 03, Sorteio2 = 06, Sorteio3 = 10, Sorteio4 = 17, Sorteio5 = 34, Sorteio6 = 37 },
                new Concurso() { Id = 2, Sorteio1 = 20, Sorteio2 = 22, Sorteio3 = 36, Sorteio4 = 42, Sorteio5 = 52, Sorteio6 = 60 },
                new Concurso() { Id = 3, Sorteio1 = 04, Sorteio2 = 28, Sorteio3 = 30, Sorteio4 = 38, Sorteio5 = 46, Sorteio6 = 59 },
                new Concurso() { Id = 4, Sorteio1 = 28, Sorteio2 = 34, Sorteio3 = 40, Sorteio4 = 43, Sorteio5 = 50, Sorteio6 = 51 }
                );

            context.Apostas.AddOrUpdate(a => a.Id,
                new Aposta() { Id = 1, ConcursoID = 1, DataHora = new DateTime(2018, 01, 02, 13, 45, 55), Jogo1 = 11, Jogo2 = 12, Jogo3 = 13, Jogo4 = 14, Jogo5 = 15, Jogo6 = 16 },
                new Aposta() { Id = 2, ConcursoID = 1, DataHora = new DateTime(2018, 01, 02, 13, 45, 55), Jogo1 = 21, Jogo2 = 22, Jogo3 = 23, Jogo4 = 24, Jogo5 = 25, Jogo6 = 26 },
                new Aposta() { Id = 3, ConcursoID = 1, DataHora = new DateTime(2018, 01, 02, 13, 45, 55), Jogo1 = 31, Jogo2 = 32, Jogo3 = 33, Jogo4 = 34, Jogo5 = 35, Jogo6 = 36 },
                new Aposta() { Id = 4, ConcursoID = 1, DataHora = new DateTime(2018, 01, 02, 13, 45, 55), Jogo1 = 41, Jogo2 = 42, Jogo3 = 43, Jogo4 = 44, Jogo5 = 45, Jogo6 = 46 },
                new Aposta() { Id = 5, ConcursoID = 1, DataHora = new DateTime(2018, 01, 02, 13, 45, 55), Jogo1 = 51, Jogo2 = 52, Jogo3 = 53, Jogo4 = 54, Jogo5 = 55, Jogo6 = 56 },
                new Aposta() { Id = 6, ConcursoID = 1, DataHora = new DateTime(2018, 01, 02, 13, 45, 55), Jogo1 = 03, Jogo2 = 06, Jogo3 = 10, Jogo4 = 17, Jogo5 = 34, Jogo6 = 37 },
                new Aposta() { Id = 7, ConcursoID = 1, DataHora = new DateTime(2018, 01, 02, 13, 45, 55), Jogo1 = 03, Jogo2 = 06, Jogo3 = 10, Jogo4 = 17, Jogo5 = 34, Jogo6 = 38 },
                new Aposta() { Id = 8, ConcursoID = 1, DataHora = new DateTime(2018, 01, 02, 13, 45, 55), Jogo1 = 03, Jogo2 = 06, Jogo3 = 10, Jogo4 = 17, Jogo5 = 35, Jogo6 = 39 },
                new Aposta() { Id = 9, ConcursoID = 1, DataHora = new DateTime(2018, 01, 02, 13, 45, 55), Jogo1 = 03, Jogo2 = 06, Jogo3 = 10, Jogo4 = 18, Jogo5 = 36, Jogo6 = 40 },
                new Aposta() { Id =10, ConcursoID = 1, DataHora = new DateTime(2018, 01, 02, 13, 45, 55), Jogo1 = 04, Jogo2 = 06, Jogo3 = 10, Jogo4 = 17, Jogo5 = 34, Jogo6 = 37 },
                new Aposta() { Id =11, ConcursoID = 1, DataHora = new DateTime(2018, 01, 02, 13, 45, 55), Jogo1 = 05, Jogo2 = 07, Jogo3 = 10, Jogo4 = 17, Jogo5 = 34, Jogo6 = 37 }
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
