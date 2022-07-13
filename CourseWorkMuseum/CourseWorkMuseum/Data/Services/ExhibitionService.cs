using CourseWorkMuseum.Data.DTOs;
using CourseWorkMuseum.Data.Models;
using Microsoft.EntityFrameworkCore;




namespace CourseWorkMuseum.Data.Services;


public class ExhibitionService
{
    private ExhibitionContext _context;

    public ExhibitionService(ExhibitionContext context)
    {
        _context = context;
    }
    


    public async Task<Exhibition?> AddExhibition(ExhibitionDto exhibition)
    {
        var nexhibition = new Exhibition
        {
            Name = exhibition.Name,
            Author = exhibition.Author,
            Date = exhibition.Date,
            Genre = exhibition.Genre
        };
        var result = _context.Exhibitions.Add(nexhibition);
        await _context.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }
    
    

    public async Task<Exhibition?> GetExhibition(int id)
    {
     //   var result = _context.Exhibitions.Include(a => a.Exhibits).Include(b => b.Visitors).FirstOrDefault(exhibition => exhibition.ExhibitionId == id);
        var result = _context.Exhibitions.FirstOrDefault(exhibition => exhibition.ExhibitionId == id);
        return await Task.FromResult(result);
    }


    public async Task<List<Exhibition>> GetExhibition()
    {
//        var result = await _context.Exhibitions.Include(a => a.Exhibits).Include(b => b.Visitors).ToListAsync();
        //var result = await _context.Exhibitions.Include(a => a.Exhibits).ToListAsync();
        var result = await _context.Exhibitions.ToListAsync();
        return await Task.FromResult(result);
    }
    

    
    public async Task<Exhibition?> UpdateExhibition(int id, Exhibition updatedExhibition)
    {
      //  var exhibition =  _context.Exhibitions.Include(a => a.Exhibits).Include(b => b.Visitors).FirstOrDefault(ex => ex.ExhibitionId == id);

      //var exhibition =  _context.Exhibitions.Include(a => a.Exhibits).FirstOrDefault(ex => ex.ExhibitionId == id);
        var exhibition =  await _context.Exhibitions.FirstOrDefaultAsync(ex => ex.ExhibitionId == id);
        if (exhibition != null)
        {
            exhibition.Name = updatedExhibition.Name;
            exhibition.Author = updatedExhibition.Author;
            exhibition.Date = updatedExhibition.Date;
            exhibition.Genre = updatedExhibition.Genre;

            // if (UpdateExhibition.Visitors.Any())
            // {
            //     exhibition.Visitors  = _context.Visitors.ToList().IntersectBy(UpdateExhibition.Visitors, article => article).ToList();
            // }

            _context.Exhibitions.Update(exhibition);
            _context.Entry(exhibition).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return exhibition;
        }
    
        return null;
    }
    

    
    public async Task<bool> DeleteExhibition(int id)
    {
        var exhibition =  await _context.Exhibitions.FirstOrDefaultAsync(a => a.ExhibitionId == id);
        if (exhibition != null)
        {
            _context.Exhibitions.Remove(exhibition);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
    

    

}

