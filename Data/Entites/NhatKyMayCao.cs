using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("NhatKyMayCao")]
    public class NhatKyMayCao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int TongHopMayCaoId { get; set; }

        public string NgayThang { get; set; } = string.Empty;

        [MaxLength(100)]
        public string DonVi { get; set; } = string.Empty;

        [MaxLength(500)]
        public string ViTri { get; set; } = string.Empty;

        [MaxLength(500)]
        public string TrangThai { get; set; } = string.Empty;

        [MaxLength(500)]
        public string GhiChu { get; set; } = string.Empty;

        [ForeignKey("TongHopMayCaoId")]
        public virtual TongHopMayCao? TongHopMayCao { get; set; }
        public virtual IEnumerable<ThongSoKyThuatMayCao>? ThongSoKyThuatMayCaos { get; set; }
    }
}