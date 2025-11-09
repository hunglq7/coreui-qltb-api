using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Neo.Tonghopneo;
using WebApi.Models.Neo.TongHopNeo;

namespace WebApi.Services
{
    public interface ITonghopneoService
    {
        Task<bool> Add(TongHopNeo request);
        Task<TongHopNeo> GetById(int id);
        Task<int> Sum();
        Task<List<TongHopNeoVm>> GetDetailById(int id);
        Task<bool> Update(TongHopNeo request);
        Task<bool> Delete(int id);
        Task<PagedResult<TongHopNeoVm>> GetAllPaging(TongHopNeoPagingRequest request);
    }

    public class TonghopneoService : ITonghopneoService
    {
        private readonly ThietbiDbContext _thietbiDbContext;

        public TonghopneoService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<bool> Add(TongHopNeo request)
        {
            if (request == null) return false;

            await _thietbiDbContext.TongHopNeos.AddAsync(request);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<TongHopNeo> GetById(int id)
        {
            return await _thietbiDbContext.TongHopNeos.FindAsync(id) ?? new TongHopNeo();
        }

        public async Task<int> Sum()
        {
            return await _thietbiDbContext.TongHopNeos.SumAsync(x => x.SoLuong);
        }

        public async Task<List<TongHopNeoVm>> GetDetailById(int id)
        {
            var query = from t in _thietbiDbContext.TongHopNeos.Where(x => x.Id == id)
                        join d in _thietbiDbContext.PhongBans on t.DonViId equals d.Id
                        join n in _thietbiDbContext.DanhmucNeos on t.NeoId equals n.Id
                        select new { t, d, n };

            return await query.Select(x => new TongHopNeoVm
            {
                Id = x.t.Id,
                TenThietBi = x.n.TenThietBi,
                TenDonVi = x.d.TenPhong,
                DonViTinh = x.t.DonViTinh,
                SoLuong = x.t.SoLuong,
                NgayLap = x.t.NgayLap,
                TinhTrangKyThuat = x.t.TinhTrangKyThuat,
                duPhong = x.t.duPhong,
                GhiChu = x.t.GhiChu
            }).ToListAsync();
        }

        public async Task<bool> Update(TongHopNeo request)
        {
            var entity = await _thietbiDbContext.TongHopNeos.FindAsync(request.Id);
            if (entity == null) return false;

            entity.NeoId = request.NeoId;
            entity.DonViId = request.DonViId;
            entity.DonViTinh = request.DonViTinh;
            entity.SoLuong = request.SoLuong;
            entity.NgayLap = request.NgayLap;
            entity.ViTriLapDat = request.ViTriLapDat;
            entity.TinhTrangKyThuat = request.TinhTrangKyThuat;
            entity.duPhong = request.duPhong;
            entity.GhiChu = request.GhiChu;

            _thietbiDbContext.Update(entity);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _thietbiDbContext.TongHopNeos.FindAsync(id);
            if (entity == null) return false;

            _thietbiDbContext.TongHopNeos.Remove(entity);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PagedResult<TongHopNeoVm>> GetAllPaging(TongHopNeoPagingRequest request)
        {
            var query = from t in _thietbiDbContext.TongHopNeos.Include(x => x.DanhmucNeo).Include(x => x.PhongBan)
                        select t;

            if (request.thietbiId > 0 && request.donviId > 0)
            {
                query = query.Where(x => x.NeoId == request.thietbiId && x.DonViId == request.donviId);
            }
            else if (request.thietbiId > 0 && (request.donviId == 0 || request.donviId == null))
            {
                query = query.Where(x => x.NeoId == request.thietbiId);
            }
            else if ((request.thietbiId == 0 || request.thietbiId == null) && request.donviId > 0)
            {
                query = query.Where(x => x.DonViId == request.donviId);
            }

            int totalRecords = await query.CountAsync();
            int sumRecords = await query.SumAsync(x => x.SoLuong);
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                                  .Take(request.PageSize)
                                  .Select(x => new TongHopNeoVm
                                  {
                                      Id = x.Id,
                                      TenThietBi = x.DanhmucNeo.TenThietBi,
                                      TenDonVi = x.PhongBan.TenPhong,
                                      DonViTinh = x.DonViTinh,
                                      SoLuong = x.SoLuong,
                                      NgayLap = x.NgayLap,
                                      ViTriLapDat = x.ViTriLapDat,
                                      TinhTrangKyThuat = x.TinhTrangKyThuat,
                                      duPhong = x.duPhong,
                                      GhiChu = x.GhiChu
                                  }).ToListAsync();

            return new PagedResult<TongHopNeoVm>
            {
                TotalRecords = totalRecords,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                SumRecords = sumRecords
            };
        }
    }
}