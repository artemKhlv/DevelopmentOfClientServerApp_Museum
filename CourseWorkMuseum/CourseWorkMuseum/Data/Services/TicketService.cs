using CourseWorkMuseum.Data.DTOs;
using CourseWorkMuseum.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWorkMuseum.Data.Services;


public class TicketService
{
    private  ExhibitionContext _context;

    public TicketService(ExhibitionContext context)
    {
        _context = context;
    }
    

    public async Task<Ticket?> AddTicket(TicketDto ticket)
    {
        var nticket = new Ticket
        {
            NameOfExhibitions = ticket.NameOfExhibitions,
            Date = ticket.Date,
            Price = ticket.Price,
            Benefits = ticket.Benefits
        };

        var result = _context.Tickets.Add(nticket);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }
    

    public async Task<Ticket?> GetTicket(int id)
    {
        var result = _context.Tickets.FirstOrDefault(ticket => ticket.TicketId == id);
        return await Task.FromResult(result);
    }

    public async Task<List<Ticket>> GetTicket()
    {
        var result = await _context.Tickets.ToListAsync();
        return await Task.FromResult(result);
    }


    public async Task<Ticket?> UpdateTicket(int id, Ticket updateTicket)
    {
        var ticket = await _context.Tickets.FirstOrDefaultAsync(au => au.TicketId == id);
        if (ticket != null)
        {
            ticket.NameOfExhibitions = updateTicket.NameOfExhibitions;
            ticket.Date = updateTicket.Date;
            ticket.Price = updateTicket.Price;
            ticket.Benefits = updateTicket.Benefits;

            _context.Tickets.Update(ticket);
            _context.Entry(ticket).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return ticket;
        }
        return null;
    }
    

    public async Task<bool> DeleteTicket(int id)
    {
        var ticket = await _context.Tickets.FirstOrDefaultAsync(a => a.TicketId == id);
        if (ticket != null)
        {
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
    

    // public async Task<List<IncompleteTicketDto>> GetTicketIncomplete()
    // {
    //     var ticket = await _context.Tickets.ToListAsync();
    //     List<IncompleteTicketDto> result = new List<IncompleteTicketDto>();
    //     ticket.ForEach(a => result.Add(new IncompleteTicketDto{TicketId = a.TicketId, NameOfExhibitions = a.NameOfExhibitions, Date = a.Date}));
    //     return await Task.FromResult(result);
    // }
}