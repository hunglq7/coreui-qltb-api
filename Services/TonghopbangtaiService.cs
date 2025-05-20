using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Danhmucbangtai;

namespace WebApi.Services
{
    public interface ITonghopbangtaiService
    {
        Task<List<TonghopbangtaiVM>> GetTonghopbangtai();
        Task<bool> AddTonghopbangtai([FromBody] TonghopbangtaiCreateRequest Request);
        Task<TongHopBangTai> GetById(int id);
        Task<int> SumTonghopbangtai();
        Task<List<TonghopbangtaiDetailByIdVM>> getDatailById(int id);
        Task<bool> UpdateTonghopbangtai([FromBody] TonghopbangtaiUpdateRequest Request);
        Task<bool> DeleteTonghopbangtai(int id);
        Task<PagedResult<TonghopbangtaiVM>> GetAllPaging(GetManagerTonghopBangtaiPagingRequest request);
    }
    public class TonghopbangtaiService : ITonghopbangtaiService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public TonghopbangtaiService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<bool> AddTonghopbangtai([FromBody] TonghopbangtaiCreateRequest Request)
        {
            if (Request == null)
            {
                return false;
            }

            var newBangTai = new TongHopBangTai()
            {
                Id = Request.Id,
                MaHieu = Request.MaHieu,
                BangTaiId = Request.BangTaiId,
                DonViId = Request.DonViId,
                ViTriLapDat = Request.ViTriLapDat,
                NgayLap = Request.NgayLap,
                Nmay = Request.Nmay,
                Lmay = Request.Lmay,
                KhungDau = Request.KhungDau,
                KhungDuoi = Request.KhungDuoi,
                KhungBangRoi = Request.KhungBangRoi,
                DayBang = Request.DayBang,
                ConLan = Request.ConLan,
                TinhTrangThietBi = Request.TinhTrangThietBi,
                GhiChu = Request.GhiChu,
            };
            await _thietbiDbContext.TongHopBangTais.AddAsync(newBangTai);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<TonghopbangtaiDetailByIdVM>> getDatailById(int id)
        {
            var Query = from t in _thietbiDbContext.TongHopBangTais.Where(x => x.Id == id)
                        join p in _thietbiDbContext.PhongBans on t.DonViId equals p.Id
                        join m in _thietbiDbContext.DanhMucBangTais on t.BangTaiId equals m.Id
                        select new { t, p, m };
            return await Query.Select(x => new TonghopbangtaiDetailByIdVM
            {
                Id = x.t.Id,
                MaHieu = x.t.MaHieu,
                TenBangTai = x.m.TenBangTai,
                TenPhong = x.p.TenPhong,
                ViTriLapDat = x.t.ViTriLapDat,
                NgayLap = x.t.NgayLap,
                Nmay = x.t.Nmay,
                Lmay = x.t.Lmay,
                KhungDau = x.t.KhungDau,
                KhungDuoi = x.t.KhungDuoi,
                KhungBangRoi = x.t.KhungBangRoi,
                DayBang = x.t.DayBang,
                ConLan = x.t.ConLan,
                TinhTrangThietBi = x.t.TinhTrangThietBi,
                GhiChu = x.t.GhiChu
            }).ToListAsync();
        }

        public async Task<bool> DeleteTonghopbangtai(int id)
        {
            var bangTai = await _thietbiDbContext.TongHopBangTais.FindAsync(id);
            if (bangTai == null)
            {
                return false;
            }
            _thietbiDbContext.TongHopBangTais.Remove(bangTai);
            _thietbiDbContext.SaveChanges();
            return true;
        }

        public async Task<TongHopBangTai> GetById(int id)
        {
            var bangTai = await _thietbiDbContext.TongHopBangTais.FindAsync(id);
            if (bangTai == null)
            {
                bangTai = new TongHopBangTai()
                {
                    Id = 0,
                    BangTaiId = 0,
                    DonViId = 0,
                    NgayLap = DateTime.Now,
                    Nmay = 0,
                    Lmay = 0,
                    KhungDau = 0,
                    KhungDuoi = 0,
                    KhungBangRoi = 0,
                    DayBang = 0,
                    ConLan = 0,
                    TinhTrangThietBi = "",
                    GhiChu = ""
                };
            }

            return bangTai;
        }

        public async Task<List<TonghopbangtaiVM>> GetTonghopbangtai()
        {
            var query = from t in _thietbiDbContext.TongHopBangTais.Include(x => x.DanhMucBangTai)
                        select t;
            return await query.Select(x => new TonghopbangtaiVM()
            {
                Id = x.Id,
                MaHieu = x.MaHieu,
                BangTaiId = x.BangTaiId,
                DonViId = x.DonViId,
                ViTriLapDat = x.ViTriLapDat,
                NgayLap = x.NgayLap,
                Nmay = x.Nmay,
                Lmay = x.Lmay,
                KhungDau = x.KhungDau,
                KhungDuoi = x.KhungDuoi,
                KhungBangRoi = x.KhungBangRoi,
                DayBang = x.DayBang,
                ConLan = x.ConLan,
                TinhTrangThietBi = x.TinhTrangThietBi,
                GhiChu = x.GhiChu,
            }).ToListAsync();
        }

        public async Task<PagedResult<TonghopbangtaiVM>> GetAllPaging(GetManagerTonghopBangtaiPagingRequest request)
        {
            var query = from t in _thietbiDbContext.TongHopBangTais.Include(x => x.DanhMucBangTai).Include(x => x.PhongBan)
                        select t;
            if (request.BangTaiId > 0 && request.DonViId > 0)
            {
                query = query.Where(x => x.BangTaiId == request.BangTaiId && x.DonViId == request.DonViId);
            }
            else if (request.DonViId > 0 && (request.DonViId == 0 || request.DonViId== null))
            {
                query = query.Where(x => x.BangTaiId == request.BangTaiId);
            }
            else if ((request.BangTaiId == 0 || request.BangTaiId == null) && request.DonViId > 0)
            {
                query = query.Where(x => x.DonViId == request.DonViId);
            }

            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new TonghopbangtaiVM()
                {
                    Id = x.Id,
                    MaHieu = x.MaHieu,
                    BangTaiId = x.BangTaiId,
                    DonViId = x.DonViId,
                    ViTriLapDat = x.ViTriLapDat,
                    NgayLap = x.NgayLap,
                    Nmay = x.Nmay,
                    Lmay = x.Lmay,
                    KhungDau = x.KhungDau,
                    KhungDuoi = x.KhungDuoi,
                    KhungBangRoi = x.KhungBangRoi,
                    DayBang = x.DayBang,
                    ConLan = x.ConLan,
                    TinhTrangThietBi = x.TinhTrangThietBi,
                    GhiChu = x.GhiChu,
                }).ToListAsync();
            var pagedResult = new PagedResult<TonghopbangtaiVM>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pagedResult;
        }

        public async Task<bool> UpdateTonghopbangtai([FromBody] TonghopbangtaiUpdateRequest Request)
        {
            var bangTai = await _thietbiDbContext.TongHopBangTais.FindAsync(Request.Id);
            if (bangTai == null)
            {
                return false;
            }
            bangTai.Id = Request.Id;
            bangTai.MaHieu = Request.MaHieu;
            bangTai.BangTaiId = Request.BangTaiId;
            bangTai.DonViId = Request.DonViId;
            bangTai.ViTriLapDat = Request.ViTriLapDat;
            bangTai.NgayLap = Request.NgayLap;
            bangTai.Nmay = Request.Nmay;
            bangTai.Lmay = Request.Lmay;
            bangTai.KhungDau = Request.KhungDau;
            bangTai.KhungDuoi = Request.KhungDuoi;
            bangTai.KhungBangRoi = Request.KhungBangRoi;
            bangTai.DayBang = Request.DayBang;
            bangTai.ConLan = Request.ConLan;
            bangTai.TinhTrangThietBi = Request.TinhTrangThietBi;
            bangTai.GhiChu = Request.GhiChu;
            _thietbiDbContext.Update(bangTai);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<int> SumTonghopbangtai()
        {
            var query = from t in _thietbiDbContext.TongHopBangTais
                        select t;
            return await query.CountAsync();
        }
    }
}