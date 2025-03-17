using Api.Models.Tonghopmayxuc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Tonghopmayxuc;
using WebApi.Models.Tonghopquatgio;

namespace WebApi.Services
{
    public interface ITonghopquatgioService
    {
  
        Task<bool> AddTonghopquatgio([FromBody] TonghopQuatgio Request);
        Task<TonghopQuatgio> GetById(int id);
        Task<int> SumTonghopquatgio();
        Task<List<TonghopquatgioVm>> getDatailById(int id);
        Task<bool> UpdateTonghopquatgio([FromBody] TonghopQuatgio Request);
        Task<bool> DeleteTonghopquatgio(int id);
        Task<PagedResult<TonghopquatgioVm>> GetAllPaging(TonghopquatgioPagingRequest request);
    }
    public class TonghopquatgioService : ITonghopquatgioService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public TonghopquatgioService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<bool> AddTonghopquatgio([FromBody] TonghopQuatgio Request)
        {
            if (Request == null)
            {
                return false;
            }

            var items = new TonghopQuatgio()
            {
                Id = Request.Id,
                MaQuanLy = Request.MaQuanLy,
                QuatGioId = Request.QuatGioId,
                DonViId = Request.DonViId,
                ViTriLapDat = Request.ViTriLapDat,
                NgayLap = Request.NgayLap,
                SoLuong = Request.SoLuong,
                TinhTrangThietBi = Request.TinhTrangThietBi,
                GhiChu = Request.GhiChu,

            };
            await _thietbiDbContext.TonghopQuatgio.AddAsync(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTonghopquatgio(int id)
        {
            var query = await _thietbiDbContext.TonghopQuatgio.FindAsync(id);
            if (query == null)
            {
                return false;
            }
            _thietbiDbContext.TonghopQuatgio.Remove(query);
            _thietbiDbContext.SaveChanges();
            return true;
        }

        public async Task<PagedResult<TonghopquatgioVm>> GetAllPaging(TonghopquatgioPagingRequest request)
        {
            var query = from t in _thietbiDbContext.TonghopQuatgio.Include(x => x.DanhmucQuatgio).Include(x => x.PhongBan)
                        select t;
            if (request.thietbiId > 0 && request.donviId > 0)
            {
                query = query.Where(x => x.QuatGioId == request.thietbiId && x.DonViId == request.donviId);
            }
            else if (request.thietbiId > 0 && (request.donviId == 0 || request.donviId == null))
            {
                query = query.Where(x => x.QuatGioId == request.thietbiId);
            }
            else if ((request.thietbiId == 0 || request.thietbiId == null) && request.donviId > 0)
            {
                query = query.Where(x => x.DonViId == request.donviId);
            }


            int totalRow = await query.CountAsync();
            int sumSoluong = await query.SumAsync(x => x.SoLuong);
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new TonghopquatgioVm()
                {
                    Id = x.Id,
                    MaQuanLy = x.MaQuanLy,
                    TenThietBi = x.DanhmucQuatgio.TenQuat,
                    TenDonVi = x.PhongBan.TenPhong,
                    ViTriLapDat = x.ViTriLapDat,
                    NgayLap = x.NgayLap,
                    SoLuong = x.SoLuong,
                    TinhTrangThietBi = x.TinhTrangThietBi,
                    GhiChu = x.GhiChu

                }).ToListAsync();
            var pagedResult = new PagedResult<TonghopquatgioVm>()
            {
                TotalRecords = totalRow,
                SumRecords=sumSoluong,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pagedResult;
        }

        public async Task<TonghopQuatgio> GetById(int id)
        {
            var query = await _thietbiDbContext.TonghopQuatgio.FindAsync(id);
            if (query == null)
            {
                query = new TonghopQuatgio()
                {
                    Id = 0,
                    QuatGioId = 0,
                    NgayLap = DateTime.Now,
                    SoLuong = 1
                }
                     ;
            }

            return query;
        }

        public async Task<List<TonghopquatgioVm>> getDatailById(int id)
        {
            var Query = from t in _thietbiDbContext.TonghopQuatgio.Where(x => x.Id == id)
                        join p in _thietbiDbContext.PhongBans on t.DonViId equals p.Id
                        join m in _thietbiDbContext.DanhmucQuatgios on t.QuatGioId equals m.Id
                      

                        select new { t, p, m};
            return await Query.Select(x => new TonghopquatgioVm
            {
                Id = x.t.Id,
                MaQuanLy = x.t.MaQuanLy,
                TenThietBi = x.m.TenQuat,
                TenDonVi = x.p.TenPhong,              
                ViTriLapDat = x.t.ViTriLapDat,
                TinhTrangThietBi = x.t.TinhTrangThietBi,
                NgayLap = x.t.NgayLap,
                SoLuong = x.t.SoLuong,
                GhiChu = x.t.GhiChu
            }).ToListAsync();
        }

     
        public async Task<int> SumTonghopquatgio()
        {
            var query = from s in _thietbiDbContext.TonghopQuatgio
                        select s;
            var sum = await query.SumAsync(x => x.SoLuong);
            return sum;
        }

        public async Task<bool> UpdateTonghopquatgio([FromBody] TonghopQuatgio Request)
        {
            var entity = await _thietbiDbContext.TonghopQuatgio.FindAsync(Request.Id);
            if (entity == null)
            {
                return false;
            }
            entity.Id = Request.Id;
            entity.MaQuanLy = Request.MaQuanLy;
            entity.QuatGioId = Request.QuatGioId;
            entity.DonViId = Request.DonViId;
            entity.ViTriLapDat = Request.ViTriLapDat;
            entity.NgayLap = Request.NgayLap;
            entity.SoLuong = Request.SoLuong;
            entity.TinhTrangThietBi = Request.TinhTrangThietBi;
            entity.GhiChu = Request.GhiChu;
            _thietbiDbContext.Update(entity);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
    }
}
