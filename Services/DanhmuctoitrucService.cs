using Api.Data.Entites;
using Api.Models.Danhmuctoitruc;
using WebApi.Data.EF;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.Common;
namespace Api.Services
{
    public interface IDanhmuctoitrucService{
          Task<List<DanhmuctoitrucVm>> GetAll();
        Task<ApiResult<int>> UpdateMultiple(List<Danhmuctoitruc> response);
        Task<ApiResult<int>> DeleteMutiple(List<Danhmuctoitruc> response);

    }
    public class DanhmuctoitrucService:IDanhmuctoitrucService
    {
         private readonly ThietbiDbContext _thietbiDbContext;
         public DanhmuctoitrucService(ThietbiDbContext thietbiDb)

         {
            _thietbiDbContext=thietbiDb;
         }
         public async Task<ApiResult<int>> DeleteMutiple(List<Danhmuctoitruc> reponse)
        {
            var ids = reponse.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");

            }

            var exitItems = _thietbiDbContext.Danhmuctoitrucs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

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

        public async Task<List<DanhmuctoitrucVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.Danhmuctoitrucs
                        select c;
            return await query.Select(x => new DanhmuctoitrucVm()
            {
                Id = x.Id,            
                TenThietBi=x.TenThietBi,
                LoaiThietBi=x.LoaiThietBi,               
                TinhTrang=x.TinhTrang,
               NamSanXuat=x.NamSanXuat,
               HangSanXuat=x.HangSanXuat,
                GhiChu=x.GhiChu,

            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<Danhmuctoitruc> reponse)
        {
            var ids = reponse.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");

            }
            var exitItems = _thietbiDbContext.Danhmuctoitrucs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitItems.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật bản ghi không hợp lệ");
            }
            _thietbiDbContext.UpdateRange(reponse);
            var count = await _thietbiDbContext.SaveChangesAsync();
            var UpdateMuliple = _thietbiDbContext.Danhmuctoitrucs.Where(x => ids.Contains(x.Id)).ToList();

            return new ApiSuccessResult<int>(count);
        }
    }
}