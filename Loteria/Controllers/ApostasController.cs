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
    public class ApostasController : ApiController
    {
        private LoteriaContext db = new LoteriaContext();

        // GET: api/Apostas
        public IQueryable<Aposta> GetApostas()
        {
            return db.Apostas;
        }

        // GET: api/Apostas/5
        [ResponseType(typeof(Aposta))]
        public async Task<IHttpActionResult> GetAposta(int id)
        {
            Aposta aposta = await db.Apostas.FindAsync(id);
            if (aposta == null)
            {
                return NotFound();
            }

            return Ok(aposta);
        }

        // PUT: api/Apostas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAposta(int id, Aposta aposta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aposta.Id)
            {
                return BadRequest();
            }

            db.Entry(aposta).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApostaExists(id))
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

        // POST: api/Apostas
        [ResponseType(typeof(Aposta))]
        public async Task<IHttpActionResult> PostAposta(Aposta aposta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Apostas.Add(aposta);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = aposta.Id }, aposta);
        }

        // DELETE: api/Apostas/5
        [ResponseType(typeof(Aposta))]
        public async Task<IHttpActionResult> DeleteAposta(int id)
        {
            Aposta aposta = await db.Apostas.FindAsync(id);
            if (aposta == null)
            {
                return NotFound();
            }

            db.Apostas.Remove(aposta);
            await db.SaveChangesAsync();

            return Ok(aposta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApostaExists(int id)
        {
            return db.Apostas.Count(e => e.Id == id) > 0;
        }
    }
}