using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Chucvu;
using WebApi.Models.Common;

namespace WebApi.Services
{
    public interface IChucvuService {
        Task<List<ChucvuVm>> GetChucvu();
        Task<ApiResult<int>> UpdateMultipleChucvu(List<ChucVu> chucvus);
        Task<ApiResult<int>> DeleteMutipleChucvu(List<ChucVu> chucvus);
        Task<bool> Add([FromBody] ChucVu Request);
        Task<bool> Update([FromBody] ChucVu Request);
        Task<bool> Delete(int id);
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
        public async Task<bool> Add([FromBody] ChucVu Request)
        {
            if (Request == null)
            {
                return false;
            }
            var newItems = new ChucVu()
            {
                TenChucVu = Request.TenChucVu,
                TrangThai = Request.TrangThai,

            };
            await _thietbiDbContext.ChucVus.AddAsync(newItems);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update([FromBody] ChucVu Request)
        {
            var items = await _thietbiDbContext.ChucVus.FindAsync(Request.Id);
            if (items == null)
            {
                return false;
            }
            items.TenChucVu = Request.TenChucVu;
            items.TrangThai = Request.TrangThai;
            _thietbiDbContext.Update(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var items = await _thietbiDbContext.ChucVus.FindAsync(id);
            if (items == null)
            {
                return false;
            }
            _thietbiDbContext.ChucVus.Remove(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
    }
}
