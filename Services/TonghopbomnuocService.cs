using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.TonghopBomnuc;
using WebApi.Models.Tonghopquatgio;


namespace WebApi.Services
{
    public interface ITonghopbomnuocService
    {
        Task<bool> Add([FromBody] TongHopBomNuoc Request);
        Task<TongHopBomNuoc> GetById(int id);
        Task<int> Sum();
        Task<List<TongHopBomNuoc>> getDatailById(int id);
        Task<bool> Update([FromBody] TongHopBomNuoc Request);
        Task<bool> Delete(int id);
        Task<PagedResult<TonghopBomnuocVm>> GetAllPaging(TonghopbomnuocPagingRequest request);
    }
    public class TonghopbomnuocService : ITonghopbomnuocService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public TonghopbomnuocService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<bool> Add([FromBody] TongHopBomNuoc Request)
        {
            if (Request == null)
            {
                return false;
            }

            var items = new TongHopBomNuoc()
            {
                Id = Request.Id,
                MaQuanLy = Request.MaQuanLy,
                BomNuocId = Request.BomNuocId,
                DonViId = Request.DonViId,
                ViTriLapDat = Request.ViTriLapDat,
                NgayLap = Request.NgayLap,
                SoLuong = Request.SoLuong,
                TinhTrangThietBi = Request.TinhTrangThietBi,
                DuPhong = Request.DuPhong,
                GhiChu = Request.GhiChu,

            };
            await _thietbiDbContext.TongHopBomNuocs.AddAsync(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var query = await _thietbiDbContext.TongHopBomNuocs.FindAsync(id);
            if (query == null)
            {
                return false;
            }
            _thietbiDbContext.TongHopBomNuocs.Remove(query);
            _thietbiDbContext.SaveChanges();
            return true;
        }

        public async Task<PagedResult<TonghopBomnuocVm>> GetAllPaging(TonghopbomnuocPagingRequest request)
        {
            var query = from t in _thietbiDbContext.TongHopBomNuocs.Include(x => x.DanhmucBomnuoc).Include(x => x.PhongBan)
                        select t;           

            if (request.duPhong != null && request.duPhong == true)
            {
                query = query.Where(x => x.DuPhong == request.duPhong);
            }
            else if (request.thietbiId > 0 && request.donviId > 0)
            {
                query = query.Where(x => x.BomNuocId == request.thietbiId && x.DonViId == request.donviId);
            }
            else if (request.thietbiId > 0 && (request.donviId == 0 || request.donviId == null))
            {
                query = query.Where(x => x.BomNuocId == request.thietbiId);
            }
            else if ((request.thietbiId == 0 || request.thietbiId == null) && request.donviId > 0)
            {
                query = query.Where(x => x.DonViId == request.donviId);
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new TonghopBomnuocVm()
                {
                    Id = x.Id,
                    MaQuanLy = x.MaQuanLy,
                    TenThietBi = x.DanhmucBomnuoc.TenThietBi,
                    TenDonVi = x.PhongBan.TenPhong,
                    ViTriLapDat = x.ViTriLapDat,
                    NgayLap = x.NgayLap,
                    SoLuong = x.SoLuong,
                    TinhTrangThietBi = x.TinhTrangThietBi,
                    DuPhong= x.DuPhong,
                    GhiChu = x.GhiChu

                }).ToListAsync();
            var pagedResult = new PagedResult<TonghopBomnuocVm>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pagedResult;
        }

        public async Task<TongHopBomNuoc> GetById(int id)
        {
            var query = await _thietbiDbContext.TongHopBomNuocs.FindAsync(id);
            if (query == null)
            {
                query = new TongHopBomNuoc()
                {
                    Id = 0,
                    BomNuocId = 0,
                    NgayLap = DateTime.Now,
                    SoLuong = 1
                }
                     ;
            }

            return query;
        }

        public async Task<List<TongHopBomNuoc>> getDatailById(int id)
        {
            var Query = from t in _thietbiDbContext.TongHopBomNuocs.Where(x => x.Id == id)
                        join p in _thietbiDbContext.PhongBans on t.DonViId equals p.Id
                        join m in _thietbiDbContext.DanhmucBomnuocs on t.BomNuocId equals m.Id


                        select new { t, p, m };
            return await Query.Select(x => new TongHopBomNuoc
            {
                Id = x.t.Id,
                MaQuanLy = x.t.MaQuanLy,
                BomNuocId = x.m.Id,
               DonViId = x.p.Id,
                ViTriLapDat = x.t.ViTriLapDat,
                TinhTrangThietBi = x.t.TinhTrangThietBi,
                NgayLap = x.t.NgayLap,
                SoLuong = x.t.SoLuong,
                DuPhong=x.t.DuPhong,
                GhiChu = x.t.GhiChu
            }).ToListAsync();
        }

        public async Task<int> Sum()
        {
            var query = from s in _thietbiDbContext.TongHopBomNuocs
                        select s;
            var sum = await query.SumAsync(x => x.SoLuong);
            return sum;
        }

        public async Task<bool> Update([FromBody] TongHopBomNuoc Request)
        {
            var entity = await _thietbiDbContext.TongHopBomNuocs.FindAsync(Request.Id);
            if (entity == null)
            {
                return false;
            }
            entity.Id = Request.Id;
            entity.MaQuanLy = Request.MaQuanLy;
            entity.BomNuocId = Request.BomNuocId;
            entity.DonViId = Request.DonViId;
            entity.ViTriLapDat = Request.ViTriLapDat;
            entity.NgayLap = Request.NgayLap;
            entity.SoLuong = Request.SoLuong;
            entity.TinhTrangThietBi = Request.TinhTrangThietBi;
            entity.DuPhong = Request.DuPhong;
            entity.GhiChu = Request.GhiChu;
            _thietbiDbContext.Update(entity);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
    }
}
