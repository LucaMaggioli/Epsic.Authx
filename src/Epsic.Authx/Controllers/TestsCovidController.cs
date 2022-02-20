using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Epsic.Authx.Data;
using Epsic.Authx.Models;
using Microsoft.AspNetCore.Authorization;

namespace Epsic.Authx.Controllers
{
    [ApiController]
    public class TestsCovidController : ControllerBase
    {
        private readonly CovidDbContext _context;

        public TestsCovidController(CovidDbContext context)
        {
            _context = context;
        }


        // GET: TestsCovid/E04832F9-6006-4E2F-8816-64E709BE38C0
        [HttpGet("testsCovid/{id}")]
        [Authorize]
        public async Task<IActionResult> Details(Guid id)
        {
            var testCovid = await _context.TestsCovid.FirstOrDefaultAsync(m => m.Id == id);
            if (testCovid == null)
            {
                return NotFound();
            }

            return Ok(testCovid);
        }

        // GET: TestsCovid/stats
        [HttpGet("testsCovid/stats")]
        public async Task<IActionResult> GetStats([FromQuery] DateTime? dateFrom, [FromQuery] DateTime? dateTo)
        {
            var stats = await _context.TestsCovid.Where(t => dateFrom == null || t.DateTest >= dateFrom)
                                           .Where(t => dateTo == null || t.DateTest <= dateTo)
                                           .GroupBy(t => new
                                           {
                                               t.TypeDeTest,
                                               t.Resultat
                                           })
                                           .Select(t => new
                                           {
                                               TypeDeTest = t.Key.TypeDeTest.ToString(),
                                               t.Key.Resultat,
                                               Nombre = t.Count()
                                           })
                                           .ToListAsync();

            return Ok(stats);
        }

        // POST: TestsCovid
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("testsCovid")]
        public async Task<IActionResult> Create([Bind("DateTest,Resultat,TypeDeTest")] TestCovid testCovid)
        {
            testCovid.Id = Guid.NewGuid();
            _context.Add(testCovid);
            await _context.SaveChangesAsync();
            return Created($"TestsCovid/{testCovid.Id}", testCovid);
        }
    }
}
