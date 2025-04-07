using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("NhatKyNeo")]
    public class NhatKyNeo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TongHopNeoId { get; set; }
        public string NgayThang { get; set; } = string.Empty;
        [MaxLength(100)]
        public string DonVi { get; set; } = string.Empty;
        [MaxLength(500)]
        public string ViTri { get; set; } = string.Empty;
        [MaxLength(500)]
        public string TrangThai { get; set; } = string.Empty;
        [MaxLength(500)]
        public string GhiChu { get; set; } = string.Empty;
        [ForeignKey("TongHopNeoId")]
        public virtual TongHopNeo? TongHopNeo { get; set; }
    }
}