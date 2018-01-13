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
    public class ConcursoesController : ApiController
    {
        private LoteriaContext db = new LoteriaContext();

        // GET: api/Concursoes
        public IQueryable<Concurso> GetConcursoes()
        {
            return db.Concursoes;
        }

        // GET: api/Concursoes/5
        [ResponseType(typeof(Concurso))]
        public async Task<IHttpActionResult> GetConcurso(int id)
        {
            Concurso concurso = await db.Concursoes.FindAsync(id);
            if (concurso == null)
            {
                return NotFound();
            }

            return Ok(concurso);
        }

        // PUT: api/Concursoes/5
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

        // POST: api/Concursoes
        [ResponseType(typeof(Concurso))]
        public async Task<IHttpActionResult> PostConcurso(Concurso concurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Concursoes.Add(concurso);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = concurso.Id }, concurso);
        }

        // DELETE: api/Concursoes/5
        [ResponseType(typeof(Concurso))]
        public async Task<IHttpActionResult> DeleteConcurso(int id)
        {
            Concurso concurso = await db.Concursoes.FindAsync(id);
            if (concurso == null)
            {
                return NotFound();
            }

            db.Concursoes.Remove(concurso);
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
            return db.Concursoes.Count(e => e.Id == id) > 0;
        }
    }
}