using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using backend.Models;

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Chapter")]
    public class ChapterController : Controller
    {
        private readonly GameContext _context;
		//static private GameManage gm = null;

        public ChapterController(GameContext context)
        {
            _context = context;
        }

        // GET: api/Chapter
        [HttpGet]
        public IEnumerable<Chapter> GetChapter()
        {
            return _context.Chapters;
        }	

        // GET: api/Chapter/5
		[HttpGet("{id}")]
        public IActionResult GetChapter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			//var actions = WebApi.Models.Action.GetActions(id);
			//List<int> allType = new List<int>();
			//rooms.ForEach(_ => allType.Add(_.RoomType));
            var chapter =  _context.Chapters.Where(_ => _.ChapterNum == id).ToList();
			if (chapter == null)
            {
                return NotFound();
            }

            return Ok(chapter);
        }

        //// PUT: api/Hotels/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutHotel([FromRoute] int id, [FromBody] Chapter hotel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

   

        //    _context.Entry(hotel).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!HotelExists(id))
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

        //// POST: api/Hotels
        //[HttpPost]
        //public async Task<IActionResult> PostChapter([FromBody] Chapter chapter)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Hotel.Add(chapter);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetHotel", new { id = chapter.Capacity }, chapter);
        //}

        //private bool HotelExists(int id)
        //{
        //    return _context.Hotel.Any(e => e.Capacity == id);
        //}
    }
}