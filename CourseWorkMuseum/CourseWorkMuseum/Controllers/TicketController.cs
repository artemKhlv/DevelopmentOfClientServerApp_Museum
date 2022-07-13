using Microsoft.AspNetCore.Mvc;
using CourseWorkMuseum.Data.DTOs;
using CourseWorkMuseum.Data.Models;
using CourseWorkMuseum.Data.Services;

namespace CourseWorkMuseum.Controllers;

[Route("api/[controller]")]
[ApiController]
internal class TicketController : ControllerBase
{
    private readonly TicketService _context;

    public TicketController(TicketService context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetTicket()
    {
        return await _context.GetTicket();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Ticket>> GetTicket(int id)
    {
        var ticket = await _context.GetTicket(id);
        if (ticket == null)
        {
            return NotFound();
        }
        return ticket;
    }




    [HttpPut("{id}")]
    public async Task<ActionResult<Ticket>> PutTicket(int id, [FromBody] Ticket ticket)
    {
        var result = await _context.UpdateTicket(id, ticket);
        if (result == null)
        {
            return BadRequest();
        }
    
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Ticket>> PostTicket([FromBody] TicketDto ticket)
    {
        var result = await _context.AddTicket(ticket);
        if (result == null)
        {
            BadRequest();
        }
        return Ok(result);
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ticket = await _context.DeleteTicket(id);
        if (ticket)
        {
            return Ok();
        }

        return BadRequest();
    }
    
    // [HttpGet("/incomplete")]
    // public async Task<ActionResult<IEnumerable<IncompleteTicketDto>>> GetTicketIncomplete()
    // {
    //     return await _context.GetTicketIncomplete();
    // }

}