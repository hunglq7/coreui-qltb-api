using WebApi.Models.Common;

namespace Api.Models.ThongsokythuatQuatgio
{
    public class GetManagerThongsokythuatquatgioPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }
    }
}