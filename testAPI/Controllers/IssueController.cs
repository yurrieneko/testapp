using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.Model;

namespace testAPI.Controllers
{
    //this [controller] is an attribute route
    //it will take controller name without the Controller word (Issue)
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IssueDbContext _context;
        public IssueController(IssueDbContext context)
        {
            _context = context;

        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            return issue == null ? NotFound() : Ok(issue);
        }

        //post
        [HttpPost]
        public async Task<IActionResult> Create(Issue issue)
        {
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = issue.Id }, issue);
        }

        [HttpGet]
        public async Task<IEnumerable<Issue>> Get()
        {
            return await _context.Issues.ToListAsync();

        }

        //update
        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, Issue issue)
        {
            if (id != issue.Id) return BadRequest();

            _context.Entry(issue).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //delete
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var IssueToDelete = await _context.Issues.FindAsync(id);
            if (IssueToDelete == null) return NotFound();

            _context.Issues.Remove(IssueToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }

}
