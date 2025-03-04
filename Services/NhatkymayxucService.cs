
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Nhatkymayxuc;


namespace WebApi.Services
{
    public interface INhatkymayxucService
    {
        Task<List<NhatkymayxucVm>> GetAll();
        Task<List<NhatkyMayxuc>> getDatailById(int id);
        Task<ApiResult<int>> UpdateMultiple(List<NhatkyMayxuc> request);
        Task<ApiResult<int>> DeleteMutiple(List<NhatkyMayxuc> request);
    }
    public class NhatkymayxucService : INhatkymayxucService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public NhatkymayxucService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<ApiResult<int>> DeleteMutiple(List<NhatkyMayxuc> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }

            var exitMayxuc = _thietbiDbContext.NhatkyMayxucs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

            var newMayxuc = exitMayxuc.Select(x => x.Id).ToList();
            var deff = ids.Except(newMayxuc).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Xóa dữ liệu không hợp lệ");
            }
            _thietbiDbContext.RemoveRange(exitMayxuc);
            var count = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<NhatkymayxucVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.NhatkyMayxucs
                        select c;
            return await query.Select(x => new NhatkymayxucVm()
            {
              Id = x.Id,
              TonghopmayxucId=x.TonghopmayxucId,
              Ngaythang=x.Ngaythang,
              DonVi=x.DonVi,
              ViTri=x.ViTri,
              TrangThai=x.TrangThai,
              GhiChu=x.GhiChu,

            }).ToListAsync();
        }

      

        public async Task<List<NhatkyMayxuc>> getDatailById(int id)
        {
            var Query = from t in _thietbiDbContext.NhatkyMayxucs.Where(x => x.TonghopmayxucId == id)
                        select t;
         
            return await Query.Select(x => new NhatkyMayxuc()
            { 
                Id=x.Id,
                TonghopmayxucId=id,
                Ngaythang=x.Ngaythang,
                DonVi=x.DonVi,
                ViTri=x.ViTri,
                TrangThai=x.TrangThai,
                GhiChu=x.GhiChu
            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<NhatkyMayxuc> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }
            var exitMayxuc = _thietbiDbContext.NhatkyMayxucs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitMayxuc.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật dữ liệu không hợp lệ");
            }
            _thietbiDbContext.UpdateRange(request);
            var count = await _thietbiDbContext.SaveChangesAsync();         

            return new ApiSuccessResult<int>(count);
        }
    }
}
