﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.TonghopBomnuc
{
    public class TonghopBomnuocVm
    {
        public int Id { get; set; }
     
        public string? MaQuanLy { get; set; }
        public string? TenThietBi { get; set; }
        public string? TenDonVi{ get; set; }
   
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }
  
        public string? TinhTrangThietBi { get; set; }
  
        public string? GhiChu { get; set; }
    }
}
