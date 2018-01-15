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
        [HttpGet]
        [ActionName("")]
        public IQueryable<Aposta> GetApostas()
        {
            return db.Apostas;
        }

        // GET: api/Apostas/5
        [HttpGet]
        [ActionName("")]
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

        // POST: api/Apostas
        [HttpPost]
        [ActionName("")]
        [ResponseType(typeof(Aposta))]
        public async Task<IHttpActionResult> PostAposta(ApostaDTO aDTO)
        {
            if (!ModelState.IsValid)
            {
                Aposta x = new Aposta()
                {
                    Id = 999
                };

                return Ok(x);
                // return BadRequest(ModelState);
            }
            Aposta aposta = new Aposta();
            aposta.ConcursoID = aDTO.ConcursoId;
            aposta.DataHora = DateTime.Now;
            aposta.Jogo1 = aDTO.Jogo[0];
            aposta.Jogo2 = aDTO.Jogo[1];
            aposta.Jogo3 = aDTO.Jogo[2];
            aposta.Jogo4 = aDTO.Jogo[3];
            aposta.Jogo5 = aDTO.Jogo[4];
            aposta.Jogo6 = aDTO.Jogo[5];

            db.Apostas.Add(aposta);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = aposta.Id }, aposta);
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