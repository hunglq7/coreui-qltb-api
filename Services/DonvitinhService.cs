using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Chucvu;
using WebApi.Models.Common;
using WebApi.Models.Donvitinh;

namespace WebApi.Services
{
    public interface IDonvitinhService
    {
        Task<List<DonvitinhVm>> GetDonvitinh();
        Task<ApiResult<int>> UpdateMultipleDonvitinh(List<DonViTinh> donvitinhs);
        Task<ApiResult<int>> DeleteMutipleDonvitinh(List<DonViTinh> donvitinhs);
    }
    public class DonvitinhService : IDonvitinhService
    {

        private readonly ThietbiDbContext _thietbiDbContext;
        public DonvitinhService(ThietbiDbContext thietbiDbContext)
        {

            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<ApiResult<int>> DeleteMutipleDonvitinh(List<DonViTinh> donvitinhs)
        {
            var ids = donvitinhs.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
               return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");

            }
          
            var exitDonvitinh = _thietbiDbContext.DonViTinhs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
           
            var newdonvitinhs = exitDonvitinh.Select(x => x.Id).ToList();
            var deff = ids.Except(newdonvitinhs).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Xóa không hợp lệ");
            }
            _thietbiDbContext.RemoveRange(exitDonvitinh);
            var count = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<DonvitinhVm>> GetDonvitinh()
        {
            var query = from c in _thietbiDbContext.DonViTinhs.Where(x => x.TrangThai == true)
                        select c;
            return await query.Select(x => new DonvitinhVm()
            {
                Id = x.Id,
                TenDonViTinh = x.TenDonViTinh,
                TrangThai = x.TrangThai,

            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultipleDonvitinh(List<DonViTinh> donvitinhs)
        {
            var ids = donvitinhs.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");

            }
            var exitDonvitinh = _thietbiDbContext.DonViTinhs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitDonvitinh.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật bản ghi không hợp lệ");
            }
            _thietbiDbContext.UpdateRange(donvitinhs);
            var count = await _thietbiDbContext.SaveChangesAsync();
            var UpdateMuliple = _thietbiDbContext.DonViTinhs.Where(x => ids.Contains(x.Id)).ToList();
          
            return new ApiSuccessResult<int>(count);
        }
    }
}
