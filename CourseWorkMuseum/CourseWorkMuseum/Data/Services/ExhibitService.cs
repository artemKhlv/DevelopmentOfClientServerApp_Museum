using CourseWorkMuseum.Data.DTOs;
using CourseWorkMuseum.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace CourseWorkMuseum.Data.Services;


public class ExhibitService
{
    private  ExhibitionContext _context;

    public ExhibitService(ExhibitionContext context)
    {
        _context = context;
    }
    
    public async Task<Exhibit?> AddExhibit(ExhibitDto exhibit)
    {
        var nexhibit = new Exhibit
        {
            Name = exhibit.Name,
            Author = exhibit.Author
        };

        var result = _context.Exhibits.Add(nexhibit);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }
    

    public async Task<Exhibit?> GetExhibit(int id)
    {
    //    var result = _context.Exhibits.Include(a => a.Exhibitions).FirstOrDefault(exhibit => exhibit.ExhibitId == id);
        var result = _context.Exhibits.FirstOrDefault(exhibit => exhibit.ExhibitId == id);
        return await Task.FromResult(result);
    }
    

    public async Task<List<Exhibit>> GetExhibit()
    {
     //   var result = await _context.Exhibits.Include(a => a.Exhibitions).ToListAsync();

        var result = await _context.Exhibits.ToListAsync();
        return await Task.FromResult(result);
    }
    

    public async Task<Exhibit?> UpdateExhibit(int id, Exhibit updateExhibit)
    {
        
    //    var exhibit = await _context.Exhibits.Include(a => a.Exhibitions).FirstOrDefaultAsync(ex => ex.ExhibitId == id);
        var exhibit = await _context.Exhibits.FirstOrDefaultAsync(ex => ex.ExhibitId == id);
        if (exhibit != null)
        {
            exhibit.Name = updateExhibit.Name;
            exhibit.Author = updateExhibit.Author;
            // if (updateExhibit.Exhibitions.Any())
            // {
            //     exhibit.Exhibitions = _context.Exhibitions.ToList()
            //         .IntersectBy(updateExhibit.Exhibitions, exhibition => exhibition).ToList();
            // }

            _context.Exhibits.Update(exhibit);
            _context.Entry(exhibit).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return exhibit;
        }
        return null;
    }


    public async Task<bool> DeleteExhibit(int id)
    {
        var exhibit = await _context.Exhibits.FirstOrDefaultAsync(a => a.ExhibitId == id);
        if (exhibit != null)
        {
            _context.Exhibits.Remove(exhibit);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
    

    // public async Task<List<IncompleteExhibitDto>> GetExhibitIncomplete()
    // {
    //     var exhibits = await _context.Exhibits.ToListAsync();
    //     List<IncompleteExhibitDto> result = new List<IncompleteExhibitDto>();
    //     exhibits.ForEach(a => result.Add(new IncompleteExhibitDto{ExhibitId = a.ExhibitId, Name = a.Name}));
    //     return await Task.FromResult(result);
    // }
}