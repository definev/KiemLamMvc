using MovieStoreMvc.Models.Domain;
using MovieStoreMvc.Models.DTO;
using MovieStoreMvc.Repositories.Abstract;

namespace MovieStoreMvc.Repositories.Implementation;

public class ArticlesService : IArticlesService
{
    private readonly DatabaseContext ctx;
    public ArticlesService(DatabaseContext ctx)
    {
        this.ctx = ctx;
    }
    
    public bool Add(Articles model)
    {
        try
        {
            ctx.Articles.Add(model);
            ctx.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool Update(Articles model)
    {
        try
        {
            ctx.Articles.Update(model);
            ctx.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Articles? GetById(int id)
    {
        return ctx.Articles.Find(id);
    }

    public bool Delete(int id)
    {
        try
        {
            var data = GetById(id);
            if (data == null)
                return false;
            ctx.Articles.Remove(data);
            ctx.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public ArticlesListVm List(string term = "", bool paging = false, int currentPage = 0)
    {
        var data = new ArticlesListVm();

        var list = ctx.Articles.ToList();
        
        if (!string.IsNullOrEmpty(term))
        {
            term = term.ToLower();
            list = list.Where(x => x?.Title?.ToLower().Contains(term.ToLower()) == true).ToList();
            data.Term = term;
        }
        
        if (paging)
        {
            var pageSize = 5;
            var count = list.Count;
            var totalPages = (int)Math.Ceiling(decimal.Divide(count, pageSize));
            list = list.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            data.PageSize = pageSize;
            data.CurrentPage = currentPage;
            data.TotalPages = totalPages;
        }

        data.Articles = list.AsQueryable();
        return data;
    }
}