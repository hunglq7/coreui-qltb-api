﻿
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Danhmucquatgio;

namespace WebApi.Services
{
    public interface IDanhmucquatgioService
    {
        Task<List<DanhmucquatgioVm>> GetAll();
        Task<ApiResult<int>> UpdateMultiple(List<DanhmucQuatgio> response);
        Task<ApiResult<int>> DeleteMutiple(List<DanhmucQuatgio> response);
    }
    public class DanhmucquatgioService : IDanhmucquatgioService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public DanhmucquatgioService(ThietbiDbContext thietbiDb)
        {
            _thietbiDbContext = thietbiDb;
        }
        public async Task<ApiResult<int>> DeleteMutiple(List<DanhmucQuatgio> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");

            }

            var exitItems = _thietbiDbContext.DanhmucQuatgios.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

            var newItems = exitItems.Select(x => x.Id).ToList();
            var deff = ids.Except(newItems).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Xóa không hợp lệ");
            }
            _thietbiDbContext.RemoveRange(exitItems);
            var count = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<DanhmucquatgioVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.DanhmucQuatgios
                        select c;
            return await query.Select(x => new DanhmucquatgioVm()
            {
                Id = x.Id,
                TenThietBi=x.TenThietBi,
                Loaithietbi=x.LoaiThietBi

            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<DanhmucQuatgio> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");

            }
            var exitItems = _thietbiDbContext.DanhmucQuatgios.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitItems.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật bản ghi không hợp lệ");
            }
            _thietbiDbContext.UpdateRange(response);
            var count = await _thietbiDbContext.SaveChangesAsync();           

            return new ApiSuccessResult<int>(count);
        }
    }
}
