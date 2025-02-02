using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("ToiTruc")]
    public class ToiTruc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string MaQuanLy { get; set; } = string.Empty;
        [MaxLength(50)]
        public string MaHieu { get; set; } = string.Empty;
        [MaxLength(50)]
        public string TenLoai { get; set; } = string.Empty;
        [MaxLength(50)]
        public string NuocSX { get; set; } = string.Empty;
        [MaxLength(50)]
        public string HangSX { get; set; } = string.Empty;
        [MaxLength(50)]
        public string NamSX { get; set; } = string.Empty;
        [MaxLength(50)]
        public string CongSuat { get; set; } = string.Empty;
        [MaxLength(50)]
        public string DienAp { get; set; } = string.Empty;
        [MaxLength(50)]
        public string SoVongQuay { get; set; } = string.Empty;
        [MaxLength(50)]
        public string LucKeo { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? TocDoKeoCham { get; set; }
        [MaxLength(50)]
        public string? TocDoKeoNhanh { get; set; }
        [MaxLength(50)]
        public  string? TrongLuongToi { get; set; }
        [MaxLength(50)]
        public string? KichThuocNgoaiHinh { get; set; }
        [MaxLength(50)]
        public string? DuongKinhCap { get; set; }
        [MaxLength(50)]
        public string? ChieuDaiCapQuan { get; set; }
        [MaxLength(50)]
        public string? ApLucKhiNen { get; set; }
        [MaxLength(50)]
        public string? LuongKhiNenTieuHao { get; set; }
        [MaxLength(50)]
        public string? GiChu { get; set; }
    }
}
