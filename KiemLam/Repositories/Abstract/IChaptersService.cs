using MovieStoreMvc.Models.Domain;
using MovieStoreMvc.Models.DTO;

namespace MovieStoreMvc.Repositories.Abstract;

public interface IChaptersService
{
    bool Add(Chapters model);
    
    bool Update(Chapters model);
    
    Chapters? GetById(int id);
    
    bool Delete(int id);
    
    ChaptersListVm List(string term = "", bool paging = false, int currentPage = 0);
}