using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entites
{
    [Table("NhatkyAptomatKhoidongtu")]
    public class NhatkyAptomatKhoidongtu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ThietBiId { get; set; }
        public string NgayThang { get; set; } = string.Empty;
        [MaxLength(100)]
        public string DonVi { get; set; } = string.Empty;
        [MaxLength(500)]
        public string ViTri { get; set; } = string.Empty;
        [MaxLength(500)]
        public string TrangThai { get; set; } = string.Empty;
        [MaxLength(500)]
        public string GhiChu { get; set; } = string.Empty;
        [ForeignKey("ThietBiId")]
        public virtual TongHopAptomatKhoidongtu? TongHopAptomatKhoidongtu { get; set; }
    }
}