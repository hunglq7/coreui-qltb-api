using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Quatgio
{
    public class QuatgioCreateRequest
    {
      
     
        public string TenQuat { get; set; } = string.Empty;
        public string LoaiThietBi { get; set; } = string.Empty;
    }
}
