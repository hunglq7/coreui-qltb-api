using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("DanhMucKhoan")]
    public class DanhMucKhoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string TenThietBi { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string LoaiThietBi { get; set; } = string.Empty;

        [MaxLength(500)]
        public string GhiChu { get; set; } = string.Empty;
        public virtual IEnumerable<TongHopKhoan>? TongHopKhoans { get; set; }
    }
}