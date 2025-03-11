using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.NhatkyBomnuoc;

namespace WebApi.Services
{
   public interface INhatkybomnuocService
    {
        Task<List<NhatkyBomnuocVm>> GetAll();
        Task<List<NhatKyBomNuoc>> getDatailById(int id);
        Task<ApiResult<int>> UpdateMultiple(List<NhatKyBomNuoc> request);
        Task<ApiResult<int>> DeleteMutiple(List<NhatKyBomNuoc> request);
    }
    public class NhatkybomnuocService:INhatkybomnuocService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public NhatkybomnuocService( ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<ApiResult<int>> DeleteMutiple(List<NhatKyBomNuoc> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }

            var exitEntity = _thietbiDbContext.NhatKyBomNuocs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

            var newEntity = exitEntity.Select(x => x.Id).ToList();
            var deff = ids.Except(newEntity).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Xóa dữ liệu không hợp lệ");
            }
            _thietbiDbContext.RemoveRange(exitEntity);
            var count = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<NhatkyBomnuocVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.NhatKyBomNuocs
                        select c;
            return await query.Select(x => new NhatkyBomnuocVm()
            {
                Id = x.Id,
                TongHopBomNuocId = x.TongHopBomNuocId,
                Ngaythang = x.Ngaythang,
                DonVi = x.DonVi,
                ViTri = x.ViTri,
                TrangThai = x.TrangThai,
                GhiChu = x.GhiChu,

            }).ToListAsync();
        }

        public async Task<List<NhatKyBomNuoc>> getDatailById(int id)
        {
            var Query = from t in _thietbiDbContext.NhatKyBomNuocs.Where(x => x.TongHopBomNuocId == id)
                        select t;
            return await Query.Select(x => new NhatKyBomNuoc()
            {
                Id = x.Id,
                TongHopBomNuocId = id,
                Ngaythang = x.Ngaythang,
                DonVi = x.DonVi,
                ViTri = x.ViTri,
                TrangThai = x.TrangThai,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<NhatKyBomNuoc> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }
            var exitEntity = _thietbiDbContext.NhatKyBomNuocs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitEntity.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật dữ liệu không hợp lệ");
            }
            _thietbiDbContext.UpdateRange(request);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }
    }
}
