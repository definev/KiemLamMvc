using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieStoreMvc.Models.Domain;

// Khoản
public class Sections
{
    [Required] public int ID { get; set; }
    [Required] public string? Title { get; set; }
    [Required] public string? Content { get; set; }
    public double? Min { get; set; }
    public double? Max { get; set; }
    public double? Avg { get; set; }
    
    public string? CreateTime { get; set; }
    public string? UpdateTime { get; set; }
    
    public int? ArticleID { get; set; }
    public int? DecreeID { get; set; }
    
    [NotMapped] public Articles? Articles { get; set; }
    [NotMapped] public List<Articles>? ArticlesList { get; set; }
 
    [NotMapped] [Required] public List<int>? ChapterIDs { get; set; }
    [NotMapped] public Chapters? Chapters { get; set; }
    [NotMapped] public IEnumerable<SelectListItem>? ChaptersList { get; set; }
}