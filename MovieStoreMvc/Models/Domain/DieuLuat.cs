using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreMvc.Models.Domain
{
    public class DieuLuat
    {
        public int Id { get; set; }
        [Required] public string? Name { get; set; }
        public string? ReleaseYear { get; set; }
        [Required] public string? Content { get; set; }

        [NotMapped] [Required] public List<int>? ChuongMuc { get; set; }
        [NotMapped] public IEnumerable<SelectListItem>? ChuongMucList { get; set; }
        [NotMapped] public string? ChuongMucNames { get; set; }
    }
}