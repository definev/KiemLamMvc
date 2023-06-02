using MovieStoreMvc.Models.Domain;
using MovieStoreMvc.Models.DTO;
using MovieStoreMvc.Repositories.Abstract;

namespace MovieStoreMvc.Repositories.Implementation;

public class ChaptersService : IChaptersService
{
    private readonly DatabaseContext ctx;
    public ChaptersService(DatabaseContext ctx)
    {
        this.ctx = ctx;
    }
    
    public bool Add(Chapters model)
    {
        try
        {
            ctx.Chapters.Add(model);
            ctx.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool Update(Chapters model)
    {
        try
        {
            ctx.Chapters.Update(model);
            ctx.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public Chapters? GetById(int id)
    {
        return ctx.Chapters.Find(id);
    }

    public bool Delete(int id)
    {
        try
        {
            var data = GetById(id);
            if (data == null)
                return false;
            ctx.Chapters.Remove(data);
            ctx.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public ChaptersListVm List(string term = "", bool paging = false, int currentPage = 0)
    {
        var data = new ChaptersListVm();

        var list = ctx.Chapters.ToList();
        
        if (!string.IsNullOrEmpty(term))
        {
            term = term.ToLower();
            list = list.Where(x => x?.Title?.Contains(term) == true).ToList();
            data.Term = term;
        }

        if (paging)
        {
            var pageSize = 5;
            var count = list.Count;
            var totalPages = (int)Math.Ceiling(decimal.Divide(count, pageSize));
            list = list.Skip(currentPage * pageSize).Take(pageSize).ToList();
            data.PageSize = pageSize;
            data.CurrentPage = currentPage;
            data.TotalPages = totalPages;
        }

        data.Chapters = list.AsQueryable();
        return data;
    }
}