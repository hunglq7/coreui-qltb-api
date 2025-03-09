﻿using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Nhatkymayxuc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApi.Services
{
    public interface INhatkyquatgioService
    {
        Task<List<NhatKyQuatGio>> GetAll();
        Task<List<NhatKyQuatGio>> getDatailById(int id);
        Task<ApiResult<int>> UpdateMultiple(List<NhatKyQuatGio> request);
        Task<ApiResult<int>> DeleteMutiple(List<NhatKyQuatGio> request);
    }
    public class NhatkyquatgioService : INhatkyquatgioService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public NhatkyquatgioService( ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext= thietbiDbContext;
        }
        public async Task<ApiResult<int>> DeleteMutiple(List<NhatKyQuatGio> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }

            var exitEntity = _thietbiDbContext.NhatKyQuatGios.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

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

        public async Task<List<NhatKyQuatGio>> GetAll()
        {
            var query = from c in _thietbiDbContext.NhatKyQuatGios
                        select c;
            return await query.Select(x => new NhatKyQuatGio()
            {
                Id = x.Id,
                TonghopquatgioId = x.TonghopquatgioId,
                Ngaythang = x.Ngaythang,
                DonVi = x.DonVi,
                ViTri = x.ViTri,
                TrangThai = x.TrangThai,
                GhiChu = x.GhiChu,

            }).ToListAsync();
        }

        public async Task<List<NhatKyQuatGio>> getDatailById(int id)
        {
            var Query = from t in _thietbiDbContext.NhatKyQuatGios.Where(x => x.TonghopquatgioId == id)
                        select t;
            return await Query.Select(x => new NhatKyQuatGio()
            {
                Id = x.Id,
                TonghopquatgioId= id,
                Ngaythang = x.Ngaythang,
                DonVi = x.DonVi,
                ViTri = x.ViTri,
                TrangThai = x.TrangThai,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<NhatKyQuatGio> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }
            var exitEntity = _thietbiDbContext.NhatKyQuatGios.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
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
