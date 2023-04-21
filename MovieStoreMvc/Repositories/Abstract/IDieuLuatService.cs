using MovieStoreMvc.Models.Domain;
using MovieStoreMvc.Models.DTO;

namespace MovieStoreMvc.Repositories.Abstract
{
    public interface IDieuLuatService
    {
       bool Add(DieuLuat model);
       bool Update(DieuLuat model);
       DieuLuat GetById(int id);
       bool Delete(int id);
       DieuLuatListVm List(string term = "", bool paging = false, int currentPage = 0);
        List<int> GetGenreByMovieId(int movieId);

    }
}
