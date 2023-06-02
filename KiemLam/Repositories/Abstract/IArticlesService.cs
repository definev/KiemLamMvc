using MovieStoreMvc.Models.Domain;
using MovieStoreMvc.Models.DTO;

namespace MovieStoreMvc.Repositories.Abstract;

public interface IArticlesService
{   
    bool Add(Articles model);
    
    bool Update(Articles model);
    
    Articles? GetById(int id);  
    
    bool Delete(int id);
    
    ArticlesListVm List(string term = "", bool paging = false, int currentPage = 0);
}