using System.ComponentModel.DataAnnotations;

namespace MovieStoreMvc.Models.Domain
{
    public class ChuongMuc
    {
        public int Id { get; set; }
        [Required]
        public string? TenChuong { get; set; }
    }
}
