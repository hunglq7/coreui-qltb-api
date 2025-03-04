using WebApi.Models.Common;

namespace Api.Models.Tonghopmayxuc
{
    public class GetManagerTonghopMayxucPagingRequest : PagingRequestBase

    {
        public string? Keyword { get; set; }
    }
}