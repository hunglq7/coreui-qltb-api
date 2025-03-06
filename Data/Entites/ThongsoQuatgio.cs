﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("ThongsoQuatgio")]
    public class ThongsoQuatgio

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int QuatgioId { get; set; }
        [MaxLength(500)]
        public string NoiDung { get; set; } = string.Empty;
        [MaxLength(100)]
        public string DonViTinh { get; set; } = string.Empty;
        [MaxLength(200)]
        public string ThongSo { get; set; } = string.Empty;
        [ForeignKey("QuatgioId")]
        public virtual DanhmucQuatgio? DanhmucQuatgio{ get; set; }
        
    }
}
