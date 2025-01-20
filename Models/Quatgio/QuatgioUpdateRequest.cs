using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Quatgio
{
    public class QuatgioUpdateRequest
    {
        public int Id { get; set; }       
        public string TenQuat { get; set; } = string.Empty;
        public string LoaiThietBi { get; set; } = string.Empty;
    }
}
