using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("TongHopAptomatKhoidongtu")]
    public class TongHopAptomatKhoidongtu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ThietBiId { get; set; }
        public int DonViId { get; set; }
        [MaxLength(200)]
        public string? ViTriLapDat { get; set; }
        public DateTime? NgayKiemDinh { get; set; }
        public DateTime? NgayLap { get; set; }
        [MaxLength(200)]
        public string? TinhTrang { get; set; }
        [MaxLength(500)]
        public string? GhiChu { get; set; }
        [ForeignKey("DonViId")]
        public virtual PhongBan? PhongBan { get; set; }
        [ForeignKey("ThietBiId")]
        public virtual DanhmucAptomatKhoidongtu? DanhmucAptomatKhoidongtu { get; set; }
        public virtual IEnumerable<Nhatkyaptomatkhoidongtu>? Nhatkyaptomatkhoidongtus { get; set; }

    }
}