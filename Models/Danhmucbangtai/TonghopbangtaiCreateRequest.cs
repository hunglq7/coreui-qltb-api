namespace WebApi.Models.Danhmucbangtai
{
    public class TonghopbangtaiCreateRequest
    {
        public int Id { get; set; }
        public string? MaHieu { get; set; }
        public int BangTaiId { get; set; }
        public int DonViId { get; set; }
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public int Nmay { get; set; }
        public int Lmay { get; set; }
        public int KhungDau { get; set; }
        public int KhungDuoi { get; set; }
        public int KhungBangRoi { get; set; }
        public int DayBang { get; set; }
        public int ConLan { get; set; }
        public string? TinhTrangThietBi { get; set; }
        public string? GhiChu { get; set; }
    }
}