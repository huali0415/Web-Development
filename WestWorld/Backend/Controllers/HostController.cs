using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Host")]
    public class HostController : Controller
    {
        private readonly GameContext _context;

        public HostController(GameContext context)
        {
            _context = context;
        }

        // GET: api/Action
        [HttpGet]
        public IEnumerable<Host> GetHost()
        {
            return _context.Hosts;
        }

		// GET: api/Action/1
		[HttpGet("{id}")]
		public IActionResult GetHost([FromRoute] int id)
		{
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var host = _context.Hosts.Where(m => m.ChapterNum == id);

            if (host.Count() ==0)
            {
                return NotFound();
            }

            return Ok(host.First());
		}

		//// GET: api/Action/5
		//[HttpGet("{name}")]
        //public IActionResult GetHost([FromRoute] string name)
        //{
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //var hosts = _context.Hosts.Where(m => m.HostName == name).ToList();

            //if (hosts == null)
            //{
            //    return NotFound();
            //}

        //    return Ok(hosts);
        //}

        // PUT: api/Record/5
        [HttpPut("{chap}")]
        public async Task<IActionResult> PutRecord([FromRoute] int chap, [FromBody] Host h)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!chap.Equals(h.ChapterNum))
            {
                return BadRequest();
            }

            var host = _context.Hosts.FirstOrDefault<Host>(c => c.ChapterNum == h.ChapterNum);

            if (!HostExists(chap))
            {
                return NotFound();
            }
            else
            {
                host.IsHostAlive = h.IsHostAlive;
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        private bool HostExists(int chap)
        {
            return _context.Hosts.Any(e => e.ChapterNum == chap);
        }
    }
}