using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Player")]

    public class PlayerController : Controller
    {
        private readonly GameContext _context;
        //static private GameManage gm = null;

        public PlayerController(GameContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult GetPlayer()
        {
            return Ok(_context.Players);
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public IActionResult GetPlayer([FromRoute]string name)
        {
            var player = _context.Players.Find(name);
            //var r = _context.Player.Where(_ => _.Name == name).ToList();

            if (player == null)
			{
				return Content("Not Found This Player!!!");
			//} else if (r.Count == 0)
            //{
                //return Ok("No Record");
            } else 
            {
                return Ok(player);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostPlayerDetails([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var p = _context.Players.Where(i => i.Name == player.Name).ToList();
            if (p.Count == 0)
			{
                _context.Players.Add(player);
				await _context.SaveChangesAsync();
				return Ok(player);
			}
			else
			{
				return Ok("Already Register! Please Login!");
			}

            //return CreatedAtAction("GetPlayer", new { name = player.Name }, player);
        }
    }
}
