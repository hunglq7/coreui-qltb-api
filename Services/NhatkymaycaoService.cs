using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.MayCao.Nhatkymaycao;

namespace WebApi.Services
{
    public interface INhatkyMayCaoService
    {
        Task<List<NhatkymaycaoVm>> GetAll();
        Task<List<NhatKyMayCao>> GetDetailById(int id);
        Task<ApiResult<int>> UpdateMultiple(List<NhatKyMayCao> request);
        Task<ApiResult<int>> DeleteMultiple(List<NhatKyMayCao> request);
    }

    public class NhatkyMayCaoService : INhatkyMayCaoService
    {
        private readonly ThietbiDbContext _thietbiDbContext;

        public NhatkyMayCaoService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<List<NhatkymaycaoVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.NhatKyMayCaos
                        select c;

            return await query.Select(x => new NhatkymaycaoVm()
            {
                Id = x.Id,
                TonghopmaycaoId = x.TongHopMayCaoId,
                NgayThang = x.NgayThang,
                DonVi = x.DonVi,
                ViTri = x.ViTri,
                TrangThai = x.TrangThai,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }

        public async Task<List<NhatKyMayCao>> GetDetailById(int id)
        {
            var query = from t in _thietbiDbContext.NhatKyMayCaos.Where(x => x.TongHopMayCaoId == id)
                        select t;

            return await query.Select(x => new NhatKyMayCao()
            {
                Id = x.Id,
                TongHopMayCaoId = id,
                NgayThang = x.NgayThang,
                DonVi = x.DonVi,
                ViTri = x.ViTri,
                TrangThai = x.TrangThai,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<NhatKyMayCao> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }

            var existingItems = _thietbiDbContext.NhatKyMayCaos.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!existingItems.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật dữ liệu không hợp lệ");
            }

            _thietbiDbContext.UpdateRange(request);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }

        public async Task<ApiResult<int>> DeleteMultiple(List<NhatKyMayCao> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }

            var existingItems = _thietbiDbContext.NhatKyMayCaos.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (existingItems.Count != ids.Count)
            {
                return new ApiErrorResult<int>("Xóa dữ liệu không hợp lệ");
            }

            _thietbiDbContext.RemoveRange(existingItems);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }
    }
}