using System.ComponentModel.DataAnnotations;

namespace MovieStoreMvc.Models.Domain;


// Điều
public class Articles
{
    public int ID { get; set; }
    [Required] public string? Title { get; set; }
    public string? Content { get; set; }
    public string? CreateTime { get; set; }
    public string? UpdateTime { get; set; }
    public int? ChapterID { get; set; }
}