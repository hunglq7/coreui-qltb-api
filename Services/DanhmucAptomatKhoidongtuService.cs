using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.AptomatKhoidongtu.DanhmucAptomatKhoidongtu;

namespace WebApi.Services
{
    public interface IDanhmucAptomatKhoidongtuService
    {
        Task<List<DanhmucAptomatKhoidongtuVm>> GetAll();
        Task<ApiResult<int>> UpdateMultiple(List<DanhmucAptomatKhoidongtu> response);
        Task<ApiResult<int>> DeleteMultiple(List<DanhmucAptomatKhoidongtu> response);
    }
    public class DanhmucAptomatKhoidongtuService : IDanhmucAptomatKhoidongtuService
    {
        public readonly ThietbiDbContext _thietbiDbContext;
        public DanhmucAptomatKhoidongtuService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<ApiResult<int>> DeleteMultiple(List<DanhmucAptomatKhoidongtu> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }
            var exitItems = _thietbiDbContext.DanhmucAptomatKhoidongtus.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
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
        public async Task<List<DanhmucAptomatKhoidongtuVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.DanhmucAptomatKhoidongtus
                        select c;
            return await query.Select(x => new DanhmucAptomatKhoidongtuVm()
            {
                Id = x.Id,
                TenThietBi = x.TenThietBi,
                LoaiThietBi = x.LoaiThietBi,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }
        public async Task<ApiResult<int>> UpdateMultiple(List<DanhmucAptomatKhoidongtu> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }
            var exitItems = _thietbiDbContext.DanhmucAptomatKhoidongtus.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
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