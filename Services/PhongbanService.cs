﻿
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Phongban;
using WebApi.Utilities.Exceptions;

namespace WebApi.Services
{
    public interface IPhongbanService
    {
        Task<List<PhongbanVm>> GetPhongban();
        Task<int> CreatePhongban(PhongbanCreateRequest request);
        //Task<PhongbanVm> GetById(int id);
        Task<int> Delete(PhongbanVm phongban);
        Task<ApiResult<int>> UpdateMultiple(List<PhongBan> response);
        Task<ApiResult<int>> DeleteMutiple(List<PhongBan> response);

    }
    public class PhongbanService : IPhongbanService
    {
        private readonly ThietbiDbContext _dbContext;
        public PhongbanService(ThietbiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreatePhongban(PhongbanCreateRequest request)
        {
           if(request == null)
            {
                return 0;
            }
            var phongban = new PhongBan()
            {
                TenPhong = request.TenPhong,
                TrangThai = request.TrangThai,
            };
             _dbContext.PhongBans.Add(phongban);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(PhongbanVm phongban)
        {
            var phong = await _dbContext.PhongBans.Where(x=>x.Id== phongban.Id).FirstOrDefaultAsync();
            if(phong == null)
            {
                throw new ThietbiException($"Cannot find a phongban");
            }
             _dbContext.Remove(phong);
            return await _dbContext.SaveChangesAsync();

        }

        public async Task<ApiResult<int>> DeleteMutiple(List<PhongBan> response)
        {
            try
            {
                var ids = response.Select(x => x.Id).ToList();
                if (ids.Count() == 0)
                {
                    return new ApiErrorResult<int>("Bạn chưa chọn bản ghi cần xóa");

                }
                if (ids.Any(x => x <= 0))
                {
                    return new ApiErrorResult<int>("Thực hiện xóa không hợp lệ");
                }
                var exitPhongban = _dbContext.PhongBans.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
               
                var phongbans = exitPhongban.Select(x => x.Id).ToList();
                var deff = ids.Except(phongbans).ToList();
                if (deff.Count > 0)
                {
                    throw new Exception("id không hợp lệ");
                }
               _dbContext.RemoveRange(exitPhongban);
                var count = await _dbContext.SaveChangesAsync();

                return new ApiSuccessResult<int>(count);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>("Lỗi kết nối máy chủ " + ex);
            }
        }

       

        public async Task<List<PhongbanVm>> GetPhongban()
        {
            var query = from p in _dbContext.PhongBans.Where(x => x.TrangThai == true)
                        select p;
            return await query.Select(x => new PhongbanVm()
            {
                Id = x.Id,
                TenPhong=x.TenPhong,
                TrangThai=x.TrangThai,

            }).ToListAsync();

        }

        public async Task<ApiResult<int>> UpdateMultiple(List<PhongBan> response)
        {
            try
            {
                var ids = response.Select(x => x.Id).ToList();
                if (ids.Count() == 0)
                {
                    return new ApiErrorResult<int>("Bạn chưa chọn bản ghi cần cập nhật");

                }
                var exitPhongban = _dbContext.PhongBans.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
                
                if (!exitPhongban.All(x => ids.Contains(x.Id)))
                {
                    return new ApiErrorResult<int>("Bạn chưa chọn bản ghi cần cập nhật");
                }
               _dbContext.UpdateRange(response);
                var count = await _dbContext.SaveChangesAsync();
                var UpdateMuliple = _dbContext.PhongBans.Where(x => ids.Contains(x.Id)).ToList();
             
                return new ApiSuccessResult<int>(count);

            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>("Lỗi kết nối hệ thống " +ex);
            }
        }
    }
}
