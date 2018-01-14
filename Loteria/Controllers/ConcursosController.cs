using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Loteria.Models;

namespace Loteria.Controllers
{
    public class ConcursosController : ApiController
    {
        private LoteriaContext db = new LoteriaContext();

        // GET: api/Concursos
        public List<ConcursoDTO> GetConcursos()
        // public IQueryable<ConcursoDTO> GetConcursos()
        {
            var c = from concurso in db.Concursos
                    select concurso;
            List<ConcursoDTO> lista = new List<ConcursoDTO>();
            foreach (Concurso concurso in c)
            {
                var cDTO = new ConcursoDTO();
                cDTO.Id = concurso.Id;
                cDTO.Sorteio.Add(concurso.Sorteio1);
                cDTO.Sorteio.Add(concurso.Sorteio2);
                cDTO.Sorteio.Add(concurso.Sorteio3);
                cDTO.Sorteio.Add(concurso.Sorteio4);
                cDTO.Sorteio.Add(concurso.Sorteio5);
                cDTO.Sorteio.Add(concurso.Sorteio6);

                lista.Add(cDTO);
            }
            return lista;
        }

        // GET: api/Concursos/5
        [ResponseType(typeof(ConcursoDTO))]
        public async Task<IHttpActionResult> GetConcurso(int id)
        {
            Concurso concurso = await db.Concursos.FindAsync(id);
            if (concurso == null)
            {
                return NotFound();
            }
            var cDTO = new ConcursoDTO();
            cDTO.Id = concurso.Id;
            cDTO.Sorteio.Add(concurso.Sorteio1);
            cDTO.Sorteio.Add(concurso.Sorteio2);
            cDTO.Sorteio.Add(concurso.Sorteio3);
            cDTO.Sorteio.Add(concurso.Sorteio4);
            cDTO.Sorteio.Add(concurso.Sorteio5);
            cDTO.Sorteio.Add(concurso.Sorteio6);


            return Ok(cDTO);
        }

        // POST: api/Concursoes
        [ResponseType(typeof(Concurso))]
        public async Task<IHttpActionResult> PostConcurso()
        {
            // Cria o próximo concurso vazio pra receber apostas e posteriormente sorteia os números.
            Concurso concurso = new Concurso();

            db.Concursos.Add(concurso);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = concurso.Id }, concurso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConcursoExists(int id)
        {
            return db.Concursos.Count(e => e.Id == id) > 0;
        }
    }
}
