using WebApi.Models.Common;
using WebApi.Data.Entites;
using WebApi.Models.Neo.Danhmucneo;
using WebApi.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public interface IDanhmucNeoService
    {
        Task<List<DanhmucNeoVm>> GetAll();
        Task<ApiResult<int>> UpdateMultiple(List<DanhmucNeo> response);
        Task<ApiResult<int>> DeleteMultiple(List<DanhmucNeo> response);
    }

    public class DanhmucNeoService : IDanhmucNeoService
    {
        private readonly ThietbiDbContext _thietbiDbContext;

        public DanhmucNeoService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<List<DanhmucNeoVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.DanhmucNeos
                        select c;

            return await query.Select(x => new DanhmucNeoVm()
            {
                Id = x.Id,
                TenThietBi = x.TenThietBi,
                LoaiThietBi = x.LoaiThietBi
            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<DanhmucNeo> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }

            var existingItems = _thietbiDbContext.DanhmucNeos.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!existingItems.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật bản ghi không hợp lệ");
            }

            _thietbiDbContext.UpdateRange(response);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }

        public async Task<ApiResult<int>> DeleteMultiple(List<DanhmucNeo> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }

            var existingItems = _thietbiDbContext.DanhmucNeos.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (existingItems.Count != ids.Count)
            {
                return new ApiErrorResult<int>("Xóa không hợp lệ");
            }

            _thietbiDbContext.RemoveRange(existingItems);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }
    }
}