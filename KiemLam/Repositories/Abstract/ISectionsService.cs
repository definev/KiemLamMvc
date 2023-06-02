using MovieStoreMvc.Models.Domain;
using MovieStoreMvc.Models.DTO;

namespace MovieStoreMvc.Repositories.Abstract;

public interface ISectionsService
{
    bool Add(Sections model);
    
    bool Update(Sections model);
    
    Sections? GetById(int id);
    
    bool Delete(int id);
    
    SectionsListVm List(string term = "", bool paging = false, int currentPage = 0);
}