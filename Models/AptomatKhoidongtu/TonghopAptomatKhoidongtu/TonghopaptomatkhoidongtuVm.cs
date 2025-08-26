using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.AptomatKhoidongtu.TonghopAptomatKhoidongtu
{
    public class TonghopaptomatkhoidongtuVm
    {
        public int Id { get; set; }
        public string MaQuanLy { get; set; } = string.Empty;
        public string TenThietBi { get; set; } = string.Empty;
        public string PhongBan { get; set; } = string.Empty;
        public string ViTriLapDat { get; set; } = string.Empty;
        public DateTime? NgayKiemDinh { get; set; }
        public DateTime? NgayLap { get; set; }
        public int SoLuong { get; set; }
        public bool DuPhong { get; set; }
        public string TinhTrangThietBi { get; set; } = string.Empty;
        public string GhiChu { get; set; } = string.Empty;
    }
}