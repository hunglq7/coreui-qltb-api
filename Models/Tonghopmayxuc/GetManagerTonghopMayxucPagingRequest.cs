using WebApi.Common;

namespace Api.Models.Tonghopmayxuc
{
    public class GetManagerTonghopMayxucPagingRequest : PagingRequestBase

    {
        public string? Keyword { get; set; }
        public int? thietbiId { get; set; }
        public int? donviId { get; set; }
    }
}