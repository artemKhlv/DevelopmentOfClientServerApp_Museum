using Microsoft.AspNetCore.Mvc;
using CourseWorkMuseum.Data.DTOs;
using CourseWorkMuseum.Data.Models;
using CourseWorkMuseum.Data.Services;

namespace CourseWorkMuseum.Controllers;

[Route("api/[controller]")]
[ApiController]
internal class ExhibitionController : ControllerBase
{
    private readonly ExhibitionService _context;

    public ExhibitionController(ExhibitionService context)
    {
        _context = context;
    }

    // private List<Exhibition> exhibitiion = new List<Exhibition>
    // {
    //     new Exhibition { Name = "Group Exhibition: Vanguards", Author = "Independent Artist", Date = "31 May - 2 July 2022", Genre = "Modern"}
    // };
    //
    // public async Task<ActionResult> GetExhibition()
    // {
    //     return Ok(exhibitiion);
    // }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Exhibition>>> GetExhibition()
    {
        return await _context.GetExhibition();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Exhibition>> GetExhibition(int id)
    {
        var exhibition = await _context.GetExhibition(id);
        if (exhibition == null)
        {
            return NotFound();
        }
        return exhibition;
    }



    //
    [HttpPut("{id}")]
    public async Task<ActionResult<Exhibition>> PutExhibition(int id, [FromBody] Exhibition exhibition)
    {
        var result = await _context.UpdateExhibition(id, exhibition);
        if (result == null)
        {
            return BadRequest();
        }
    
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Exhibition>> PostExhibition([FromBody] ExhibitionDto exhibition)
    {
        var result = await _context.AddExhibition(exhibition);
        if (result == null)
        {
            BadRequest();
        }
        return Ok(result);
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var exhibition = await _context.DeleteExhibition(id);
        if (exhibition)
        {
            return Ok();
        }

        return BadRequest();
    }
    



}

