using Microsoft.EntityFrameworkCore;
using WebApi.Models.Common;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.NhatkyTonghoptoitruc;



namespace WebApi.Services
{
    public interface INhatkyTonghoptoitrucService
    {
        Task<List<NhatkyTonghoptoitrucVm>> GetAll();
        Task<List<NhatkyTonghoptoitruc>> getDetailById(int id);
        Task<ApiResult<int>> UpdateMultiple(List<NhatkyTonghoptoitruc> request);
        Task<ApiResult<int>> DeleteMutiple(List<NhatkyTonghoptoitruc> request);
    }
    public class NhatkyTonghoptoitrucService:INhatkyTonghoptoitrucService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public NhatkyTonghoptoitrucService( ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext=thietbiDbContext;
            
        }

        public async Task<ApiResult<int>> DeleteMutiple(List<NhatkyTonghoptoitruc> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }

            var exitNhatky = _thietbiDbContext.NhatkyTonghoptoitrucs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

            var newNhatky = exitNhatky.Select(x => x.Id).ToList();
            var deff = ids.Except(newNhatky).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Xóa dữ liệu không hợp lệ");
            }
            _thietbiDbContext.RemoveRange(exitNhatky);
            var count = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<NhatkyTonghoptoitrucVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.NhatkyTonghoptoitrucs
                        select c;
            return await query.Select(x => new NhatkyTonghoptoitrucVm()
            {
                Id = x.Id,
                TonghoptoitrucId = x.TonghoptoitrucId,
                Ngaythang = x.Ngaythang,
                DonVi = x.DonVi,
                ViTri = x.ViTri,
                TrangThai = x.TrangThai,
                GhiChu = x.GhiChu,

            }).ToListAsync();
        }

        public async Task<List<NhatkyTonghoptoitruc>> getDetailById(int id)
        {
            var Query = from t in _thietbiDbContext.NhatkyTonghoptoitrucs.Where(x => x.TonghoptoitrucId == id)
                        select t;

            return await Query.Select(x => new NhatkyTonghoptoitruc()
            {
                Id = x.Id,
                TonghoptoitrucId = id,
                Ngaythang = x.Ngaythang,
                DonVi = x.DonVi,
                ViTri = x.ViTri,
                TrangThai = x.TrangThai,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<NhatkyTonghoptoitruc> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }
            var exitNhatky = _thietbiDbContext.NhatkyTonghoptoitrucs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitNhatky.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật dữ liệu không hợp lệ");
            }
            _thietbiDbContext.UpdateRange(request);
            var count = await _thietbiDbContext.SaveChangesAsync();
            var UpdateMuliple = _thietbiDbContext.Cameras.Where(x => ids.Contains(x.Id)).ToList();

            return new ApiSuccessResult<int>(count);
        }
    }
}
