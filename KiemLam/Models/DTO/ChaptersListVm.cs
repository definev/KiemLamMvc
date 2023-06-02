using MovieStoreMvc.Models.Domain;

namespace MovieStoreMvc.Models.DTO;

public class ChaptersListVm
{
    public IQueryable<Chapters>? Chapters { get; set; }
    
    public int PageSize { get; set; }   
    
    public int CurrentPage { get; set; }
    
    public int TotalPages { get; set; }
    
    public string? Term { get; set; }
}