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
        public string? MaQuanLy { get; set; }
        public int aptomatkhoidongtuId { get; set; }
        public int DonViId { get; set; }
        [MaxLength(200)]
        public string? ViTriLapDat { get; set; }
        public DateTime? NgayKiemDinh { get; set; }
        public DateTime? NgayLap { get; set; }
        public int SoLuong { get; set; }
        [MaxLength(200)]
        public string? TinhTrangThietBi { get; set; }
        public bool DuPhong { get; set; }
        [MaxLength(500)]
        public string? GhiChu { get; set; }
        [ForeignKey("DonViId")]
        public virtual PhongBan? PhongBan { get; set; }
        [ForeignKey("aptomatkhoidongtuId")]
        public virtual DanhmucAptomatKhoidongtu? DanhmucAptomatKhoidongtu { get; set; }
        public virtual IEnumerable<Nhatkyaptomatkhoidongtu>? Nhatkyaptomatkhoidongtus { get; set; }

    }
}