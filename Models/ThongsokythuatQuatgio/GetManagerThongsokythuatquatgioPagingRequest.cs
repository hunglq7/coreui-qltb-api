using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;

namespace Api.Models.ThongsokythuatQuatgio
{
    public class GetManagerThongsokythuatquatgioPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }
    }
}