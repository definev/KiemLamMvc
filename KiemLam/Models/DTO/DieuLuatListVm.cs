using MovieStoreMvc.Models.Domain;

namespace MovieStoreMvc.Models.DTO
{
    public class SectionsListVm 
    {
        public IQueryable<Sections>? Sections { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }
    }
}
