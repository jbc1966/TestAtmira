using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_Atmira.Models;



namespace Test_Atmira.Controllers
{
    [Route("api/Episodes")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        static HttpClient client = new HttpClient();
       
        private readonly TestAtmiraContext _context;

        private void setup()
        {
            client.BaseAddress = null;
            client.BaseAddress = new Uri("https://api.tvmaze.com/shows/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

        public EpisodesController(TestAtmiraContext context)
        {
            _context = context;
        }



        // GET: api/Episodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Episode>> GetEpisode(int id, bool saveDataLoaded=false)
        {
            setup();

            Episode episodio = null;

            string path = client.BaseAddress.ToString() + id;

            HttpResponseMessage respuesta = await client.GetAsync(path);
            if(respuesta.IsSuccessStatusCode)
            {
                episodio = await respuesta.Content.ReadFromJsonAsync<Episode>();
            }

          //  var episode = await _context.Episodes.FindAsync(id);

            if (episodio == null)
            {
                return NotFound();
            }
            else
            {
                if(saveDataLoaded)
                {
                    _ = PostEpisode(episodio);
                }
            }

            return episodio;
        }

        // GET: api/Episodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Episode>>> GetEpisodes()
        {
            return await _context.Episodes.ToListAsync();
        }

        // POST: api/Episodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Episode>> PostEpisode(Episode episode)
        {
            _context.Episodes.Add(episode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEpisode", new { id = episode.Id }, episode);
        }



        //// PUT: api/Episodes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEpisode(int id, Episode episode)
        //{
        //    if (id != episode.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(episode).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EpisodeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        //// DELETE: api/Episodes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEpisode(int id)
        //{
        //    var episode = await _context.Episodes.FindAsync(id);
        //    if (episode == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Episodes.Remove(episode);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool EpisodeExists(int id)
        {
            return _context.Episodes.Any(e => e.Id == id);
        }
    }
}
