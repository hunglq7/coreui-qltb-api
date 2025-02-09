using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Data.Entites
{
    [Table("ThongsokythuatToitruc")]
    public class ThongsokythuatToitruc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int Id { get; set; }
        public int DanhmuctoitrucId { get; set; }
        [Required]
        [MaxLength(2000)]
        public string NoiDung { get; set; } = string.Empty;
        [MaxLength(50)]
        public string DonViTinh { get; set; }=string.Empty;
        [MaxLength(100)]
        public string ThongSo { get; set; }=string.Empty ;
        [ForeignKey("DanhmuctoitrucId")]
        public virtual Danhmuctoitruc? Danhmuctoitruc{get;set;}

    }
}