namespace WebApi.Models.Danhmucbangtai
{
    public class NhatkybangtaiVM
    {
        public int Id { get; set; }
        public int BangTaiId { get; set; }
        public DateTime NgaySuDung { get; set; }
        public string? NoiDung { get; set; }
        public string? GhiChu { get; set; }
    }
}