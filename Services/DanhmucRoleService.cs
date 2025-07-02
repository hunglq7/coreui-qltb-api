using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.DanhmucRole;
using WebApi.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public interface IDanhmucRoleService
    {
        // Define methods for the DanhmucRoleService here
        Task<List<DanhmucRoleVm>> GetAll();
        Task<ApiResult<int>> UpdateMultiple(List<DanhMucRole> response);
        Task<ApiResult<int>> DeleteMultiple(List<DanhMucRole> response);
    }
    public class DanhmucRoleService:IDanhmucRoleService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public DanhmucRoleService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<ApiResult<int>> DeleteMultiple(List<DanhMucRole> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }

            var existingItems = _thietbiDbContext.DanhMucRoles.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (existingItems.Count != ids.Count)
            {
                return new ApiErrorResult<int>("Xóa không hợp lệ");
            }

            _thietbiDbContext.RemoveRange(existingItems);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<DanhmucRoleVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.DanhMucRoles
                        select c;

            return await query.Select(x => new DanhmucRoleVm()
            {
                Id = x.Id,
                TenThietBi = x.TenThietBi,
                LoaiThietBi = x.LoaiThietBi
                
            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<DanhMucRole> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }

            var existingItems = _thietbiDbContext.DanhMucRoles.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!existingItems.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật bản ghi không hợp lệ");            }

            _thietbiDbContext.UpdateRange(response);
            var count = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }
    }
}
