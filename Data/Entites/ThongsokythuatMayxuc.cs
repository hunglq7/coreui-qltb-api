using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("ThongsokythuatMayxuc")]
    public class ThongsokythuatMayxuc
    {
        public int Id { get; set; }
        public int MayXucId { get; set; }
        public string NoiDung { get; set; } = string.Empty;
        public string DonViTinh { get; set; }=string.Empty;
        public string ThongSo { get; set; }=string.Empty ;

        public virtual MayXuc? MayXuc { get; set; }
    }
}
