namespace WebApi.Models.Neo.TongHopNeo
{
    public class TongHopNeoVm
    {
        public int Id { get; set; }
        public string TenThietBi { get; set; } = string.Empty;
        public string TenDonVi { get; set; } = string.Empty;
        public string DonViTinh { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public string NgayLap { get; set; } = string.Empty;
        public string TinhTrangKyThuat { get; set; } = string.Empty;
        public string GhiChu { get; set; } = string.Empty;
    }
}