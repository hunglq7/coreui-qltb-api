using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using Api.Models.AptomatKhoidongtu.TonghopAptomatKhoidongtu;

namespace WebApi.Services
{
    public interface ITonghopaptomatkhoidongtuService
    {
        Task<bool> Add([FromBody] TongHopAptomatKhoidongtu Request);
        Task<TongHopAptomatKhoidongtu> GetById(int id);
        Task<int> Sum();
        Task<List<TonghopaptomatkhoidongtuVm>> GetDataiById(int id);
        Task<bool> Update([FromBody] TongHopAptomatKhoidongtu Request);
        Task<bool> Delete(int id);
        Task<PagedResult<TonghopaptomatkhoidongtuVm>> GetAllPaging(TonghopaptomatkhoidongduPagingRequest request);
    }

    public class TonghopaptomatkhoidongtuService : ITonghopaptomatkhoidongtuService
    {
        private readonly ThietbiDbContext _thietbiDbContext;

        public TonghopaptomatkhoidongtuService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<bool> Add([FromBody] TongHopAptomatKhoidongtu Request)
        {
            if (Request == null)
            {
                return false;
            }
            var items = new TongHopAptomatKhoidongtu()
            {
                Id = Request.Id,
                MaQuanLy=Request.MaQuanLy,
                aptomatkhoidongtuId = Request.aptomatkhoidongtuId,
                DonViId = Request.DonViId,
                ViTriLapDat = Request.ViTriLapDat,
                NgayKiemDinh = Request.NgayKiemDinh,
                NgayLap = Request.NgayLap,
                SoLuong = Request.SoLuong,
                TinhTrangThietBi = Request.TinhTrangThietBi,
                DuPhong = Request.DuPhong,
                GhiChu = Request.GhiChu
            };
            await _thietbiDbContext.TongHopAptomatKhoidongtus.AddAsync(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var query = await _thietbiDbContext.TongHopAptomatKhoidongtus.FindAsync(id);
            if (query == null)
            {
                return false;
            }
            _thietbiDbContext.TongHopAptomatKhoidongtus.Remove(query);
            _thietbiDbContext.SaveChanges();
            return true;
        }

        public async Task<PagedResult<TonghopaptomatkhoidongtuVm>> GetAllPaging(TonghopaptomatkhoidongduPagingRequest request)
        {
            var query = from t in _thietbiDbContext.TongHopAptomatKhoidongtus.Include(x => x.DanhmucAptomatKhoidongtu).Include(x => x.PhongBan)
                        select t;

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.ViTriLapDat.Contains(request.Keyword) ||
                                       x.TinhTrangThietBi.Contains(request.Keyword) ||
                                       x.GhiChu.Contains(request.Keyword));
            }

            if (request.aptomatkhoidongtuId > 0 && request.DonViId > 0)
            {
                query = query.Where(x => x.aptomatkhoidongtuId == request.aptomatkhoidongtuId && x.DonViId == request.DonViId);
            }
            else if (request.aptomatkhoidongtuId > 0 && (request.DonViId == 0 || request.DonViId == null))
            {
                query = query.Where(x => x.aptomatkhoidongtuId == request.aptomatkhoidongtuId);
            }
            else if ((request.aptomatkhoidongtuId == 0 || request.aptomatkhoidongtuId == null) && request.DonViId > 0)
            {
                query = query.Where(x => x.DonViId == request.DonViId);
            }

            int totalRow = await query.CountAsync();
            int SumRecodes= await query.SumAsync(x => x.SoLuong);
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new TonghopaptomatkhoidongtuVm()
                {
                    Id = x.Id,
                    MaQuanLy = x.MaQuanLy ?? string.Empty,
                    TenThietBi = x.DanhmucAptomatKhoidongtu.TenThietBi,
                    PhongBan = x.PhongBan.TenPhong,
                    ViTriLapDat = x.ViTriLapDat,
                    NgayKiemDinh = x.NgayKiemDinh,
                    NgayLap = x.NgayLap,
                    SoLuong = x.SoLuong,
                    DuPhong = x.DuPhong,
                    TinhTrangThietBi = x.TinhTrangThietBi,
                    GhiChu = x.GhiChu
                }).ToListAsync();

            var pagedResult = new PagedResult<TonghopaptomatkhoidongtuVm>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                SumRecords=SumRecodes
            };
            return pagedResult;
        }

        public async Task<TongHopAptomatKhoidongtu> GetById(int id)
        {
            var query = await _thietbiDbContext.TongHopAptomatKhoidongtus.FindAsync(id);
            if (query == null)
            {
                query = new TongHopAptomatKhoidongtu()
                {
                    Id = 0,
                    aptomatkhoidongtuId = 0,
                    DonViId = 0,
                    NgayLap = DateTime.Now
                };
            }
            return query;
        }

        public async Task<List<TonghopaptomatkhoidongtuVm>> GetDataiById(int id)
        {
            var Query = from t in _thietbiDbContext.TongHopAptomatKhoidongtus.Where(x => x.Id == id)
                        join p in _thietbiDbContext.PhongBans on t.DonViId equals p.Id
                        join m in _thietbiDbContext.DanhmucAptomatKhoidongtus on t.aptomatkhoidongtuId equals m.Id
                        select new { t, p, m };

            return await Query.Select(x => new TonghopaptomatkhoidongtuVm
            {
                Id = x.t.Id,
                MaQuanLy = x.t.MaQuanLy ?? string.Empty,
                TenThietBi = x.m.TenThietBi,
                PhongBan = x.p.TenPhong,
                ViTriLapDat = x.t.ViTriLapDat,
                NgayKiemDinh = x.t.NgayKiemDinh,
                NgayLap = x.t.NgayLap,
                TinhTrangThietBi = x.t.TinhTrangThietBi,
                DuPhong = x.t.DuPhong,
                GhiChu = x.t.GhiChu
            }).ToListAsync();
        }

        public async Task<int> Sum()
        {
            var query = from s in _thietbiDbContext.TongHopAptomatKhoidongtus
                        select s;
            var count = await query.CountAsync();
            return count;
        }

        public async Task<bool> Update([FromBody] TongHopAptomatKhoidongtu Request)
        {
            var entity = await _thietbiDbContext.TongHopAptomatKhoidongtus.FindAsync(Request.Id);
            if (entity == null)
            {
                return false;
            }
            entity.MaQuanLy = Request.MaQuanLy;
            entity.aptomatkhoidongtuId= Request.aptomatkhoidongtuId;
            entity.DonViId = Request.DonViId;
            entity.ViTriLapDat = Request.ViTriLapDat;
            entity.NgayKiemDinh = Request.NgayKiemDinh;
            entity.NgayLap = Request.NgayLap;
            entity.TinhTrangThietBi = Request.TinhTrangThietBi;
            entity.SoLuong = Request.SoLuong;
            entity.DuPhong = Request.DuPhong;
            entity.GhiChu = Request.GhiChu;
            _thietbiDbContext.Update(entity);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
    }
}