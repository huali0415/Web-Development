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
    [Route("api/Choice")]
    public class ChoiceController : Controller
    {
        private readonly GameContext _context;

        public ChoiceController(GameContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult GetChoice()
        {
            return Ok(_context.Choices);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetChoice([FromRoute]int id)
        {
            var options = _context.Choices.Where(_ => _.ChapterNum == id).ToList();

            if (options.Count == 0)
            {
                return Content("Not Found This Story!!!");
            }
            else
            {
                return Ok(options);
            }
        }
    }
}