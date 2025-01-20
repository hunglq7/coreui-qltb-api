using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Chucvu;
using WebApi.Models.Common;
using WebApi.Models.Phongban;

namespace WebApi.Services
{
    public interface IChucvuService {
        Task<List<ChucvuVm>> GetChucvu();
        Task<ApiResult<int>> UpdateMultipleChucvu(List<ChucVu> chucvus);
        Task<ApiResult<int>> DeleteMutipleChucvu(List<ChucVu> chucvus);
    }
    public class ChucvuService : IChucvuService
    {

        private readonly ThietbiDbContext _thietbiDbContext;
        public ChucvuService(ThietbiDbContext thietbiDbContext)
        {

            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<ApiResult<int>> DeleteMutipleChucvu(List<ChucVu> chucvus)
        {
            var ids = chucvus.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }

            var exitChucvu = _thietbiDbContext.ChucVus.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
           
            var newchucvus = exitChucvu.Select(x => x.Id).ToList();
            var deff = ids.Except(newchucvus).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Xóa dữ liệu không hợp lệ");
            }
            _thietbiDbContext.RemoveRange(exitChucvu);
            var count = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<ChucvuVm>> GetChucvu()
        {
            var query = from c in _thietbiDbContext.ChucVus.Where(x => x.TrangThai == true)
                        select c;
            return await query.Select(x => new ChucvuVm()
            {
                Id = x.Id,
                TenChucVu = x.TenChucVu,
                TrangThai = x.TrangThai,

            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultipleChucvu(List<ChucVu> chucvus)
        {
            var ids = chucvus.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }
            var exitChucvu = _thietbiDbContext.ChucVus.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitChucvu.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật dữ liệu không hợp lệ");
            }
            _thietbiDbContext.UpdateRange(chucvus);
           var count=  await _thietbiDbContext.SaveChangesAsync();
            var UpdateMuliple = _thietbiDbContext.ChucVus.Where(x => ids.Contains(x.Id)).ToList();
            
            return new ApiSuccessResult<int>(count);
        }
    }
}
