﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entites
{
    [Table("NhatKyBomNuoc")]
    public class NhatKyBomNuoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TongHopBomNuocId { get; set; }
        public string Ngaythang { get; set; } = string.Empty;
        [MaxLength(100)]
        public string DonVi { get; set; } = string.Empty;
        [MaxLength(500)]
        public string ViTri { get; set; } = string.Empty;
        [MaxLength(500)]
        public string TrangThai { get; set; } = string.Empty;
        [MaxLength(500)]
        public string GhiChu { get; set; } = string.Empty;
        [ForeignKey("TongHopBomNuocId")]
        public virtual TongHopBomNuoc? TongHopBomNuoc { get;set; }
    }
}
