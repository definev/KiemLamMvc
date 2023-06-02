using Microsoft.Build.Framework;

namespace MovieStoreMvc.Models.Domain;

public class Chapters
{
    [Required] public int ID { get; set; }
    [Required] public string? Title { get; set; }
    [Required] public string? Content { get; set; }
    public string? CreateTime { get; set; }
    public string? UpdateTime { get; set; }
    public int? Decree { get; set; } 
}