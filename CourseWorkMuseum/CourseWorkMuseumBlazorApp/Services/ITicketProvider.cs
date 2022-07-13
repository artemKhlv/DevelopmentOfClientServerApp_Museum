using CourseWorkMuseumBlazorApp.Data.Models;

namespace CourseWorkMuseumBlazorApp.Services;

public interface ITicketProvider
{
    Task<List<Ticket>> GetAll();
    Task<Ticket> GetOne(int id);
    Task<bool> Add(Ticket item);
    Task<Ticket> Edit(Ticket item);
    Task<bool> Remove(int id);

}