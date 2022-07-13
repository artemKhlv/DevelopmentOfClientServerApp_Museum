using CourseWorkMuseumBlazorApp.Data.Models;

namespace CourseWorkMuseumBlazorApp.Services;

public interface IExhibitProvider
{
    Task<List<Exhibit>> GetAll();
    Task<Exhibit> GetOne(int id);
    Task<bool> Add(Exhibit item);
    Task<Exhibit> Edit(Exhibit item);
    Task<bool> Remove(int id);

}