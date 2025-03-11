﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("ThongSoBomNuoc")]
    public class ThongSoBomNuoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }
        public int BomNuocId { get; set; }
        [MaxLength(500)]
        public string NoiDung { get; set; } = string.Empty;
        [MaxLength(100)]
        public string DonViTinh { get; set; } = string.Empty;
        [MaxLength(200)]
        public string ThongSo { get; set; } = string.Empty;
        [ForeignKey("BomNuocId")]
        public virtual DanhmucBomnuoc? DanhmucBomnuoc { get; set; }

    }
}
