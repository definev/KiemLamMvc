using MovieStoreMvc.Models.Domain;

namespace MovieStoreMvc.Models.DTO;

public class ArticlesListVm
{
    public IQueryable<Articles>? Articles { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public string? Term { get; set; }
}