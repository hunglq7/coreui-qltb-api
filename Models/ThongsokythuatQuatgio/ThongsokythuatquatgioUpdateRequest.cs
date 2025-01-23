namespace WebApi.Models.ThongsokythuatQuatgio
{
    public class ThongsokythuatquatgioUpdateRequest
    {
        public int Id { get; set; }
        public int QuatgioId { get; set; }

        public string NuocSX { get; set; } = string.Empty;

        public string DuongKinhBanhCT { get; set; } = string.Empty;

        public int SoBanhCT { get; set; }

        public string TocDo { get; set; } = string.Empty;

        public string LuuLuong { get; set; } = string.Empty;

        public string HaAp { get; set; } = string.Empty;

        public string CongSuat { get; set; } = string.Empty;

        public string KichThuoc { get; set; } = string.Empty;

        public string ChieuDai { get; set; } = string.Empty;

        public string GhiChu { get; set; } = string.Empty;
    }
}
