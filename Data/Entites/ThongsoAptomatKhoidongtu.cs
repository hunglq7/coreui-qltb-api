using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("ThongsoAptomatKhoidongtu")]
    public class ThongsoAptomatKhoidongtu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DanhmucaptomatKhoidongtuId { get; set; }
        [Required]
        [MaxLength(2000)]
        public string NoiDung { get; set; } = string.Empty;
        [MaxLength(50)]
        public string DonViTinh { get; set; } = string.Empty;
        [MaxLength(100)]
        public string ThongSo { get; set; } = string.Empty;
        [ForeignKey("DanhmucaptomatKhoidongtuId")]
        public virtual DanhmucAptomatKhoidongtu? DanhmucAptomatKhoidongtu { get; set; }
    }
}