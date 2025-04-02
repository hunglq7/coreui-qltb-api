using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.MayCao.Tonghopmaycao;

namespace WebApi.Services
{
    public interface ITonghopmaycaoService
    {
        Task<bool> Add(TongHopMayCao request);
        Task<TongHopMayCao> GetById(int id);
        Task<int> Sum();
        Task<List<TonghopmaycaoVm>> GetDetailById(int id);
        Task<bool> Update(TongHopMayCao request);
        Task<bool> Delete(int id);
        Task<PagedResult<TonghopmaycaoVm>> GetAllPaging(TonghopmaycaoPagingRequest request);
    }

    public class TonghopmaycaoService : ITonghopmaycaoService
    {
        private readonly ThietbiDbContext _thietbiDbContext;

        public TonghopmaycaoService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<bool> Add(TongHopMayCao request)
        {
            if (request == null) return false;

            await _thietbiDbContext.TongHopMayCaos.AddAsync(request);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<TongHopMayCao> GetById(int id)
        {
            return await _thietbiDbContext.TongHopMayCaos.FindAsync(id) ?? new TongHopMayCao();
        }

        public async Task<int> Sum()
        {
            return await _thietbiDbContext.TongHopMayCaos.SumAsync(x => x.SoLuong);
        }

        public async Task<List<TonghopmaycaoVm>> GetDetailById(int id)
        {
            var query = from t in _thietbiDbContext.TongHopMayCaos.Where(x => x.Id == id)
                        join d in _thietbiDbContext.PhongBans on t.DonViId equals d.Id
                        join m in _thietbiDbContext.DanhmucMayCaos on t.MayCaoId equals m.Id
                        select new { t, d, m };

            return await query.Select(x => new TonghopmaycaoVm
            {
                Id = x.t.Id,
                MaQuanLy = x.t.MaQuanLy,
                TenThietBi = x.m.TenThietBi,
                TenDonVi = x.d.TenPhong,
                ViTriLapDat = x.t.ViTriLapDat,
                NgayLap = x.t.NgayLap,
                SoLuong = x.t.SoLuong,
                ChieuDaiMay = x.t.ChieuDaiMay,
                SoLuongXich = x.t.SoLuongXich,
                SoLuongCauMang = x.t.SoLuongCauMang,
                TinhTrangThietBi = x.t.TinhTrangThietBi,
                GhiChu = x.t.GhiChu
            }).ToListAsync();
        }

        public async Task<bool> Update(TongHopMayCao request)
        {
            var entity = await _thietbiDbContext.TongHopMayCaos.FindAsync(request.Id);
            if (entity == null) return false;

            entity.MaQuanLy = request.MaQuanLy;
            entity.MayCaoId = request.MayCaoId;
            entity.DonViId = request.DonViId;
            entity.ViTriLapDat = request.ViTriLapDat;
            entity.NgayLap = request.NgayLap;
            entity.SoLuong = request.SoLuong;
            entity.ChieuDaiMay = request.ChieuDaiMay;
            entity.SoLuongXich = request.SoLuongXich;
            entity.SoLuongCauMang = request.SoLuongCauMang;
            entity.TinhTrangThietBi = request.TinhTrangThietBi;
            entity.GhiChu = request.GhiChu;

            _thietbiDbContext.Update(entity);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _thietbiDbContext.TongHopMayCaos.FindAsync(id);
            if (entity == null) return false;

            _thietbiDbContext.TongHopMayCaos.Remove(entity);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PagedResult<TonghopmaycaoVm>> GetAllPaging(TonghopmaycaoPagingRequest request)
        {
            var query = from t in _thietbiDbContext.TongHopMayCaos.Include(x => x.DanhmucMayCao).Include(x => x.PhongBan)
                        select t;

            if (request.thietbiId > 0 && request.donviId > 0)
            {
                query = query.Where(x => x.MayCaoId == request.thietbiId && x.DonViId == request.donviId);
            }
            else if (request.thietbiId > 0 && (request.donviId == 0 || request.donviId == null))
            {
                query = query.Where(x => x.MayCaoId == request.thietbiId);
            }
            else if ((request.thietbiId == 0 || request.thietbiId == null) && request.donviId > 0)
            {
                query = query.Where(x => x.DonViId == request.donviId);
            }

            int totalRecords = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                                  .Take(request.PageSize)
                                  .Select(x => new TonghopmaycaoVm
                                  {
                                      Id = x.Id,
                                      MaQuanLy = x.MaQuanLy,
                                      TenThietBi = x.DanhmucMayCao.TenThietBi,
                                      TenDonVi = x.PhongBan.TenPhong,
                                      ViTriLapDat = x.ViTriLapDat,
                                      NgayLap = x.NgayLap,
                                      SoLuong = x.SoLuong,
                                      ChieuDaiMay = x.ChieuDaiMay,
                                      SoLuongXich = x.SoLuongXich,
                                      SoLuongCauMang = x.SoLuongCauMang,
                                      TinhTrangThietBi = x.TinhTrangThietBi,
                                      GhiChu = x.GhiChu
                                  }).ToListAsync();

            return new PagedResult<TonghopmaycaoVm>
            {
                TotalRecords = totalRecords,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
        }
    }
}