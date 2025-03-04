using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Loaithietbi;

namespace WebApi.Services
{
    public interface ILoaithietbiService
    {
        Task<List<LoaithietbiVm>> GetLoaithietbi();
        Task<ApiResult<int>> UpdateMultipleLoaithietbi(List<LoaiThietBi> loaithietbis);
        Task<ApiResult<int>> DeleteMutipleLoaithietbi(List<LoaiThietBi> loaithietbis);
    }
    public class LoaithietbiService : ILoaithietbiService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public LoaithietbiService(ThietbiDbContext thietbiDbContext)
        {

            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<ApiResult<int>> DeleteMutipleLoaithietbi(List<LoaiThietBi> loaithietbis)
        {
            var ids = loaithietbis.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");

            }
           
            var exitLoaithietbi = _thietbiDbContext.LoaiThietBis.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
         
            var newLoaithietbis = exitLoaithietbi.Select(x => x.Id).ToList();
            var deff = ids.Except(newLoaithietbis).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Xóa dữ liệu không hợp lệ");
            }
            _thietbiDbContext.RemoveRange(exitLoaithietbi);
            var count=  await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<LoaithietbiVm>> GetLoaithietbi()
        {
            var query = from c in _thietbiDbContext.LoaiThietBis.Where(x => x.TrangThai == true)
                        select c;
            return await query.Select(x => new LoaithietbiVm()
            {
                Id = x.Id,
                TenLoai = x.TenLoai,
                TrangThai = x.TrangThai,

            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultipleLoaithietbi(List<LoaiThietBi> loaithietbis)
        {
            var ids = loaithietbis.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");

            }
            var exitLoaithietbi = _thietbiDbContext.LoaiThietBis.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitLoaithietbi.All(x => ids.Contains(x.Id)))
            {
                throw new Exception("Tất cả id không tồn tại trong database");
            }
            _thietbiDbContext.UpdateRange(loaithietbis);
            var count = await _thietbiDbContext.SaveChangesAsync();
            var UpdateMuliple = _thietbiDbContext.LoaiThietBis.Where(x => ids.Contains(x.Id)).ToList();
        
            return new ApiSuccessResult<int>(count);
        }
    }
}
