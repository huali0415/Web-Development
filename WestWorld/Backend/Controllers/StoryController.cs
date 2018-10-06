using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Story")]
    public class StoryController : Controller
    {
        private readonly GameContext _context;

        public StoryController(GameContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult GetStory()
        {
            return Ok(_context.Stories);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetStory([FromRoute]int id)
        {
            var s = _context.Stories.Where(_ => _.ChapterNum == id).ToList();

            if (s == null)
            {
                return Content("Not Found This Story!!!");
            }
            else
            {
                return Ok(s);
            }
        }
    }
}
