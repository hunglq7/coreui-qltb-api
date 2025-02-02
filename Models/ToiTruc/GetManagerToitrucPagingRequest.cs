using WebApi.Common;

namespace WebApi.Models.ToiTruc
{
    public class GetManagerToitrucPagingRequest:PagingRequestBase
    {
        public string? Keyword { get; set; }
    }
}
