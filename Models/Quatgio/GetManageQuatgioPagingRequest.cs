using WebApi.Common;

namespace WebApi.Models.Quatgio
{
    public class GetManageQuatgioPagingRequest: PagingRequestBase
    {
        public string? Keyword { get; set; }
    }
}
