using Microsoft.AspNetCore.Mvc;
using CourseWorkMuseum.Data.DTOs;
using CourseWorkMuseum.Data.Models;
using CourseWorkMuseum.Data.Services;

namespace CourseWorkMuseum.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExhibitController : ControllerBase
{
    private readonly ExhibitService _context;

    public ExhibitController(ExhibitService context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Exhibit>>> GetExhibit()
    {
        return await _context.GetExhibit();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Exhibit>> GetExhibit(int id)
    {
        var exhibit = await _context.GetExhibit(id);
        if (exhibit == null)
        {
            return NotFound();
        }
        return exhibit;
    }




    [HttpPut("{id}")]
    public async Task<ActionResult<Exhibit>> PutExhibit(int id, [FromBody] Exhibit exhibit)
    {
        var result = await _context.UpdateExhibit(id, exhibit);
        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Exhibit>> PostExhibit([FromBody] ExhibitDto exhibit)
    {
        var result = await _context.AddExhibit(exhibit);
        if (result == null)
        {
            BadRequest();
        }
        return Ok(result);
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var exhibit = await _context.DeleteExhibit(id);
        if (exhibit)
        {
            return Ok();
        }

        return BadRequest();
    }
    
    // [HttpGet("/incomplete")]
    // public async Task<ActionResult<IEnumerable<IncompleteExhibitDto>>> GetExhibitIncomplete()
    // {
    //     return await _context.GetExhibitIncomplete();
    // }

}