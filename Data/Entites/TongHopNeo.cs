using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("TongHopNeo")]
    public class TongHopNeo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int NeoId { get; set; }
        public int DonViId { get; set; }
        [MaxLength(100)]
        public string DonViTinh { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public string NgayLap { get; set; } = string.Empty;
        [MaxLength(500)]
        public string ViTriLapDat { get; set; } = string.Empty;
        [MaxLength(500)]
        public string TinhTrangKyThuat { get; set; } = string.Empty;
        public Boolean duPhong { get; set; }
        [MaxLength(500)]
        public string GhiChu { get; set; } = string.Empty;

        [ForeignKey("NeoId")]
        public virtual DanhmucNeo? DanhmucNeo { get; set; }
        [ForeignKey("DonViId")]
        public virtual PhongBan? PhongBan { get; set; }
    }
}