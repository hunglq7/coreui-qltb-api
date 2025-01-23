using Api.Data.Entites;
using Api.Models.ThongsokythuatQuatgio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.Data.EF;
using WebApi.Models.Quatgio;
using WebApi.Models.ThongsokythuatQuatgio;

namespace Api.Services
{
    public interface IThongsokythuatquatgioService
    {
        Task<int> Create(ThongsokythuatquatgioCreateRequest response);
        Task<int> Update(ThongsokythuatquatgioUpdateRequest request);
        Task<int> Delete(int id);
        Task<PagedResult<ThongsokythuatquatgioVm>> GetAllPaging(GetManagerThongsokythuatquatgioPagingRequest request);
    }
    public class ThongsokythuatquatgioService : IThongsokythuatquatgioService
    {
        public readonly ThietbiDbContext _thietbiDbContext;
        public ThongsokythuatquatgioService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;

        }
        public async Task<int> Create(ThongsokythuatquatgioCreateRequest response)
        {
            if (response == null)
            {
                return 0;
            }
            var items = new ThongsokythuatQuatgio()
            {
                QuatgioId = response.QuatgioId,
                NuocSX = response.NuocSX,
                DuongKinhBanhCT = response.DuongKinhBanhCT,
                SoBanhCT = response.SoBanhCT,
                TocDo = response.TocDo,
                LuuLuong = response.LuuLuong,
                HaAp = response.HaAp,
                CongSuat = response.CongSuat,
                KichThuoc = response.KichThuoc,
                ChieuDai = response.ChieuDai,
                GhiChu = response.GhiChu
            };
            await _thietbiDbContext.ThongsokythuatQuatgios.AddAsync(items);
            var count = _thietbiDbContext.SaveChanges();
            return count;

        }

    
        public async Task<int> Delete(int id)
        {
            var query = _thietbiDbContext.ThongsokythuatQuatgios.Find(id);
            if (query == null)
            {
                return 0;
            }
            _thietbiDbContext.ThongsokythuatQuatgios.Remove(query);
            var count = await _thietbiDbContext.SaveChangesAsync();
            return count;
        }

        public async Task<PagedResult<ThongsokythuatquatgioVm>> GetAllPaging(GetManagerThongsokythuatquatgioPagingRequest request)
        {
            var query = from t in _thietbiDbContext.ThongsokythuatQuatgios.Include(q => q.Quatgio)
                        select t;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query=query.Where(x=>x.Quatgio.TenQuat.ToLower().Contains(request.Keyword.ToLower()));
            }
            int totalRow = await query.CountAsync();           
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ThongsokythuatquatgioVm()
                {
                    Id = x.Id,
                    QuatgioId = x.QuatgioId,
                    TenQuat = x.Quatgio.TenQuat,
                    NuocSX = x.NuocSX,
                    DuongKinhBanhCT = x.DuongKinhBanhCT,
                    SoBanhCT = x.SoBanhCT,
                    TocDo = x.TocDo,
                    LuuLuong = x.LuuLuong,
                    HaAp = x.HaAp,
                    CongSuat = x.CongSuat,
                    KichThuoc = x.KichThuoc,
                    ChieuDai = x.ChieuDai,
                  
                }).ToListAsync();
            var pagedResult = new PagedResult<ThongsokythuatquatgioVm>()
            {
               TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<int> Update(ThongsokythuatquatgioUpdateRequest request)
        {
            var query= _thietbiDbContext.ThongsokythuatQuatgios.Find(request.Id);
            if (query == null)
            {
                return 0;
            }
            query.QuatgioId = request.QuatgioId;
            query.NuocSX = request.NuocSX;
            query.DuongKinhBanhCT = request.DuongKinhBanhCT;
            query.SoBanhCT = request.SoBanhCT;
            query.TocDo = request.TocDo;
            query.LuuLuong = request.LuuLuong;
            query.HaAp = request.HaAp;
            query.CongSuat = request.CongSuat;
            query.KichThuoc = request.KichThuoc;
            query.ChieuDai = request.ChieuDai;
            query.GhiChu = request.GhiChu;
           var count=await _thietbiDbContext.SaveChangesAsync();
            return count;

        }
    }
}