using CourseWorkMuseumBlazorApp.Data.Models;

namespace CourseWorkMuseumBlazorApp.Services;

public interface IExhibitionProvider
{
    Task<List<Exhibition>> GetAll();
    Task<Exhibition> GetOne(int id);
    Task<bool> Add(Exhibition item);
    Task<Exhibition> Edit(Exhibition item);
    Task<bool> Remove(int id);

}