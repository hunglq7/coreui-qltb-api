using WebApi.Models.Common;
namespace WebApi.Models.TonghopRole
{
    public class TonghopRolePagingRequest:PagedResultBase
    {
        public int? thietbiId { get; set; }
        public int? donviId { get; set; }
    }
}
