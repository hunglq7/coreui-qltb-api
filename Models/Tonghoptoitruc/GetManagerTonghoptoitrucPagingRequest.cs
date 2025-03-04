using WebApi.Models.Common;

namespace WebApi.Models.Tonghoptoitruc
{
    public class GetManagerTonghoptoitrucPagingRequest:PagingRequestBase
    {
        public string? Keyword { get; set; }
    }
}
