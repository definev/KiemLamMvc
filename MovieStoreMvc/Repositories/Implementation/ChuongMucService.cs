using MovieStoreMvc.Models.Domain;
using MovieStoreMvc.Repositories.Abstract;

namespace MovieStoreMvc.Repositories.Implementation
{
    public class ChuongMucService : IChuongMucService
    {
        private readonly DatabaseContext ctx;
        public ChuongMucService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(ChuongMuc model)
        {
            try
            {
                ctx.ChuongMuc.Add(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            } 
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;
                ctx.ChuongMuc.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ChuongMuc GetById(int id)
        {
            return ctx.ChuongMuc.Find(id);
        }

        public IQueryable<ChuongMuc> List()
        {
            var data = ctx.ChuongMuc.AsQueryable();
            return data;
        }

        public bool Update(ChuongMuc model)
        {
            try
            {
                ctx.ChuongMuc.Update(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
