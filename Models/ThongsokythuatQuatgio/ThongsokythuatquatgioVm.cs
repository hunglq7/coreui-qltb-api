using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.ThongsokythuatQuatgio
{
    public class ThongsokythuatquatgioVm
    {
        public int Id { get; set; }
        public int QuatgioId { get; set; }
        public string TenQuat { get; set; } = string.Empty;
        public string NuocSX { get; set; } = string.Empty;

        public string DuongKinhBanhCT { get; set; } = string.Empty;

        public int SoBanhCT { get; set; }

        public string TocDo { get; set; } = string.Empty;

        public string LuuLuong { get; set; } = string.Empty;

        public string HaAp { get; set; } = string.Empty;

        public string CongSuat { get; set; } = string.Empty;

        public string KichThuoc { get; set; } = string.Empty;

        public string ChieuDai { get; set; } = string.Empty;


    }
}