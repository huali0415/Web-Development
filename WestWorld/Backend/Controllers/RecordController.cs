using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
	[Produces("application/json")]
	[Route("api/Record")]
	public class RecordController : Controller
	{
		private readonly GameContext _context;
        static private GameManage gm = null;

		public RecordController(GameContext context)
        {
            if (_context == null)
            {
                _context = context;

            }
            if (gm == null)
            {
                gm = new GameManage();
                _context.Players.AddRange(gm._players);
                _context.Records.AddRange(gm._records);
                _context.Chapters.AddRange(gm._chapters);
                _context.Hosts.AddRange(gm._hosts);
                _context.Stories.AddRange(gm._stories);
                _context.Choices.AddRange(gm._choices);
                _context.SaveChanges();
            }

        }

		public IActionResult GetRecord()
		{
            return Ok(_context.Records);
		}

        // GET: api/Record/Name
		[HttpGet("{Name}")]
		public IActionResult GetRecord(string Name)
		{
            var r = _context.Records.Where(_ => _.PlayerName == Name);
            if (r.Count() ==0)
			{
				return Ok("No Record");
			}
			else
			{
                return Ok(r.Last());
			}
			
		}

		 // POST: api/Record
		[HttpPost("{Name}")]
        public async Task<IActionResult> PostRecord([FromRoute]string Name, [FromBody] Record r)
		{
            int RecordNum = _context.Records.Count() + 1;
            r.RecordNum = RecordNum;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var p = _context.Records.Where(i => i.PlayerName == Name).ToList();
            _context.Records.Add(r);
            await _context.SaveChangesAsync();
            return Ok(r);
			
		}

        // PUT: api/Record/5
        [HttpPut("{name}")]
        public async Task<IActionResult> PutRecord([FromRoute] string name, [FromBody] Record r)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!name.Equals(r.PlayerName))
            {
                return BadRequest();
            }

            _context.Entry(r).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!RecordExists(name))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return NoContent();
        }

        private bool RecordExists(string name)
         {
             return _context.Records.Any(e => e.PlayerName == name);
         }

        // DELETE: api/ItemDetails/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteRecord([FromRoute] string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var record = await _context.Records.SingleOrDefaultAsync(m => m.PlayerName == name);
            if (record == null)
            {
                return NotFound();
            }

            _context.Records.Remove(record);
            await _context.SaveChangesAsync();

            return Ok(record);
        }
	}
}