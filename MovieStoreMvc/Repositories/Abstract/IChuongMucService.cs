using MovieStoreMvc.Models.Domain;

namespace MovieStoreMvc.Repositories.Abstract
{
    public interface IChuongMucService
    {
       bool Add(ChuongMuc model);
       bool Update(ChuongMuc model);
       ChuongMuc GetById(int id);
       bool Delete(int id);
       IQueryable<ChuongMuc> List();

    }
}
