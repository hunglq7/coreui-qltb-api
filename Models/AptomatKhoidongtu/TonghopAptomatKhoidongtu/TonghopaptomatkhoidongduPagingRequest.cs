using WebApi.Models.Common;

namespace Api.Models.AptomatKhoidongtu.TonghopAptomatKhoidongtu
{
    public class TonghopaptomatkhoidongduPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }
        public int? ThietBiId { get; set; }
        public int? DonViId { get; set; }
    }
} 