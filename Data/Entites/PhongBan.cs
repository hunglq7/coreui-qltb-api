using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("PhongBan")]
    public class PhongBan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string TenPhong { get; set; } = string.Empty;
        public bool TrangThai { get; set; }
        public virtual IEnumerable<NhanVien>? NhanViens { get; set; }
        public virtual IEnumerable<TongHopThietBi>? TongHopThietBis { get; set; }
        public virtual IEnumerable<TheoDoiSuaChua>? TheoDoiSuaChuas { get; set; }
        public virtual IEnumerable<TongHopMayXuc>? TongHopMayXucs { get; set; }
        public virtual IEnumerable<TonghopCamera>? TonghopCameras { get; set; }
        public virtual IEnumerable<NhatkyCamera>? NhatkyCameras { get; set; }
        public virtual IEnumerable<TongHopToiTruc>? TongHopToiTrucs { get; set; }
        public virtual IEnumerable<Tonghopcapdien>? Tonghopcapdiens { get; set; }
        public virtual IEnumerable<TonghopQuatgio>? TonghopQuatgio { get; set; }
        public virtual IEnumerable<TongHopBomNuoc>? TongHopBomNuocs { get; set; }
        public virtual IEnumerable<TonghopBalang>? TonghopBalangs { get; set; }
        public virtual IEnumerable<TongHopKhoan>? TongHopKhoans { get; set; }
        public virtual IEnumerable<TongHopMayCao>? TongHopMayCaos { get; set; }
        public virtual IEnumerable<TongHopNeo>? TongHopNeos { get; set; }
        public virtual IEnumerable<TongHopBangTai>? TongHopBangTais { get; set; }
        public virtual IEnumerable<TongHopRole>? TongHopRoles { get; set; }
        public virtual IEnumerable<Tonghopgiacotthuyluc>? Tonghopgiacotthuylucs { get; set; }
        public virtual IEnumerable<TongHopAptomatKhoidongtu>? TongHopAptomatKhoidongtus { get; set; }
    }
}
