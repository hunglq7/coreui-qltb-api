using WebApi.Common;
using WebApi.Models.Common;
namespace WebApi.Models.Quatgio
{
    public class GetManageQuatgioPagingRequest: PagingRequestBase
    {
        public string? Keyword { get; set; }
    }
}
