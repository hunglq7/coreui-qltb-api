﻿using WebApi.Models.Common;
namespace WebApi.Models.TonghopRole
{
    public class TonghopRolePagingRequest:PagedResultBase
    {
     
        public int? donViId { get; set; }
        public Boolean duPhong { get; set; }
    }
}
