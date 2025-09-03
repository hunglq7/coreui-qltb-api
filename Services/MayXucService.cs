using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Mayxuc;

namespace WebApi.Services
{
    public interface IMayXucService
    {
        Task<List<MayXucVM>> GetMayXuc();
        Task<ApiResult<int>> UpdateMultipleMayXuc(List<MayXuc> listMayxuc);
        Task<ApiResult<int>> DeleteMutipleMayXuc(List<MayXuc> listMayxuc);

    }
    public class MayXucService : IMayXucService
    {
        private readonly ThietbiDbContext _thietbiDbContext;

      
        public MayXucService(ThietbiDbContext thietbiDbContext)
        {

            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<ApiResult<int>> DeleteMutipleMayXuc(List<MayXuc> listMayxuc)
        {
            var ids = listMayxuc.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");

            }

            var exitMayXuc = _thietbiDbContext.MayXucs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

            var newMayxucs = exitMayXuc.Select(x => x.Id).ToList();
            var deff = ids.Except(newMayxucs).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Xóa không hợp lệ");
            }
            _thietbiDbContext.RemoveRange(exitMayXuc);
            var count = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<MayXucVM>> GetMayXuc()
        {
            var query = from c in _thietbiDbContext.MayXucs
                        select c;
            return await query.Select(x => new MayXucVM()
            {
                Id = x.Id, 
                MaTaiSan = x.MaTaiSan,
                TenThietBi=x.TenThietBi,
                LoaiThietBi=x.LoaiThietBi,               
                TinhTrang=x.TinhTrang,
               NamSanXuat=x.NamSanXuat,
               HangSanXuat=x.HangSanXuat,
                GhiChu=x.GhiChu,

            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultipleMayXuc(List<MayXuc> listMayxuc)
        {
            var ids = listMayxuc.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");

            }
            var exitMayXuc = _thietbiDbContext.MayXucs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitMayXuc.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật bản ghi không hợp lệ");
            }
            _thietbiDbContext.UpdateRange(listMayxuc);
            var count = await _thietbiDbContext.SaveChangesAsync();
            var UpdateMuliple = _thietbiDbContext.MayXucs.Where(x => ids.Contains(x.Id)).ToList();

            return new ApiSuccessResult<int>(count);
        }
    }
}
