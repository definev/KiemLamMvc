using MovieStoreMvc.Models.Domain;
using MovieStoreMvc.Models.DTO;
using MovieStoreMvc.Repositories.Abstract;

namespace MovieStoreMvc.Repositories.Implementation
{
    public class SectionsService : ISectionsService
    {
        private readonly DatabaseContext ctx;
        public SectionsService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Sections model)
        {
            try
            {
                ctx.Sections.Add(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(Sections model)
        {
            try
            {
                ctx.Sections.Update(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Sections? GetById(int id)
        {
            return ctx.Sections.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var data = GetById(id);
                if (data == null)
                    return false;
                ctx.Sections.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public SectionsListVm List(string term = "", bool paging = false, int currentPage = 0)
        {
            var data = new SectionsListVm();

            var list = ctx.Sections.ToList();

            if (!string.IsNullOrEmpty(term))
            {
                term = term.ToLower();
                list = list.Where(a => a?.Title?.ToLower().Contains(term) == true).ToList();
                data.Term = term;
            }
            
            if (paging)
            {
                var pageSize = 5;
                var count = list.Count;
                var totalPages = (int)Math.Ceiling(count / (double)pageSize);
                list = list.Skip((currentPage - 1)*pageSize).Take(pageSize).ToList();
                data.PageSize = pageSize;
                data.CurrentPage = currentPage;
                data.TotalPages = totalPages;
            }

            data.Sections = list.AsQueryable();
            return data;
        }
    }
}
