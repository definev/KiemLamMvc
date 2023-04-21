using System.ComponentModel.DataAnnotations;

namespace MovieStoreMvc.Models.Domain
{
    public class DieuLuatChuongMuc
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int ChuongMucId { get; set; }
    }
}
