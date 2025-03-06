﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Tonghopquatgio
{
    public class TonghopquatgioVm
    {
        public int Id { get; set; }      
        public string? MaQuanLy { get; set; }
        public string? TenThietBi { get; set; }
        public string? TenDonVi { get; set; }
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }     
        public string? TinhTrangThietBi { get; set; }   
        public string? GhiChu { get; set; }
    }
}
