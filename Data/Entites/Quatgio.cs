using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Data.Entites;

namespace WebApi.Data.Entites
{
    [Table("QuatGio")]
    public class Quatgio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string TenQuat { get; set; } = string.Empty;
        [MaxLength(200)]
        public string LoaiThietBi { get; set; } = string.Empty;
        public virtual IEnumerable<ThongsokythuatQuatgio>? ThongsokythuatQuatgios{get;set;}

    }
}
