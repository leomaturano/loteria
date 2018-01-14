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
    public class ResultadoController : ApiController
    {
        private LoteriaContext db = new LoteriaContext();

        // GET: api/Resultado
        public IQueryable<Concurso> GetConcursos()
        {
            return db.Concursos;
        }

        // GET: api/Resultado/5
        [ResponseType(typeof(Concurso))]
        public async Task<IHttpActionResult> GetConcurso(int id)
        {
            Concurso concurso = await db.Concursos.FindAsync(id);
            if (concurso == null)
            {
                return NotFound();
            }

            return Ok(concurso);
        }

        // PUT: api/Resultado/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConcurso(int id, Concurso concurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != concurso.Id)
            {
                return BadRequest();
            }

            db.Entry(concurso).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConcursoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Resultado
        [ResponseType(typeof(Concurso))]
        public async Task<IHttpActionResult> PostConcurso(Concurso concurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Concursos.Add(concurso);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = concurso.Id }, concurso);
        }

        // DELETE: api/Resultado/5
        [ResponseType(typeof(Concurso))]
        public async Task<IHttpActionResult> DeleteConcurso(int id)
        {
            Concurso concurso = await db.Concursos.FindAsync(id);
            if (concurso == null)
            {
                return NotFound();
            }

            db.Concursos.Remove(concurso);
            await db.SaveChangesAsync();

            return Ok(concurso);
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