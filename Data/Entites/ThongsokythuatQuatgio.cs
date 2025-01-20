using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Data.Entites;

namespace Api.Data.Entites
{
    [Table("ThongsokythuatQuatgio")]
    public class ThongsokythuatQuatgio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }
        public int QuatgioId { get; set; }
        [MaxLength(50)]
        public string NuocSX { get; set; }=string.Empty;
        [MaxLength(50)]
        public string DuongKinhBanhCT { get; set; }=string.Empty;
        [MaxLength(50)]
        public int SoBanhCT { get; set; }
        [MaxLength(50)]
        public string TocDo { get; set; }=string.Empty;
        [MaxLength(50)]
        public string LuuLuong { get; set; }=string.Empty;
        [MaxLength(50)]
        public string HaAp { get; set; }=string.Empty;
        [MaxLength(50)]
        public string CongSuat { get; set; }=string.Empty;
        [MaxLength(50)]
        public string KichThuoc { get; set; }=string.Empty;
        [MaxLength(50)]
        public string ChieuDai { get; set; }=string.Empty;
        [MaxLength(200)]
        public string GhiChu { get; set; }=string.Empty;
[ForeignKey("QuatgioId")]
        public virtual Quatgio? Quatgio{get;set;}
        
    }
}