using Api.Models.Tonghopmayxuc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Tonghopmayxuc;


namespace WebApi.Services
{
    public interface ITonghopmayxucService
    {
        Task<List<TonghopmayxucVM>> GetTonghopmayxuc();
        Task<bool> AddTonghopmayxuc([FromBody] MayxucCreateRequest Request);
        Task<TongHopMayXuc> GetById(int id);
        Task<int> SumTonghopmayxuc();
        Task<List<TonghopmayDetailByIdVm>> getDatailById(int id);
        Task<bool> UpdateTonghopmayxuc([FromBody] MayxucUpdateRequest Request);
        Task<bool> DeleteTonghopmayxuc(int id);
        Task<PagedResult<TonghopmayxucVM>> GetAllPaging(GetManagerTonghopMayxucPagingRequest request);

    }
    public class TonghopmayxucService : ITonghopmayxucService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public TonghopmayxucService(ThietbiDbContext thetbiDbContext)
        {
            _thietbiDbContext = thetbiDbContext;
        }

        public async Task<bool> AddTonghopmayxuc([FromBody] MayxucCreateRequest Request)
        {
            if (Request == null)
            {
                return false;
            }

            var newmayxuc = new TongHopMayXuc()
            {
                Id = Request.Id,
                MaQuanLy = Request.MaQuanLy,
                MayXucId = Request.MayXucId,
                PhongBanId = Request.PhongBanId,
                LoaiThietBiId = Request.LoaiThietBiId,
                ViTriLapDat = Request.ViTriLapDat,
                NgayLap = Request.NgayLap,
                SoLuong = Request.SoLuong,
                TinhTrang = Request.TinhTrang,
                GhiChu = Request.GhiChu,

            };
            await _thietbiDbContext.TongHopMayXucs.AddAsync(newmayxuc);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<TonghopmayDetailByIdVm>> getDatailById(int id)
        {
            var Query = from t in _thietbiDbContext.TongHopMayXucs.Where(x => x.Id == id)
                        join p in _thietbiDbContext.PhongBans on t.PhongBanId equals p.Id
                        join m in _thietbiDbContext.MayXucs on t.MayXucId equals m.Id
                        join l in _thietbiDbContext.LoaiThietBis on t.LoaiThietBiId equals l.Id

                        select new { t, p, m, l };
            return await Query.Select(x => new TonghopmayDetailByIdVm
            {
                Id = x.t.Id,
                MaQuanLy = x.t.MaQuanLy,
                TenMay = x.m.TenThietBi,
                TenPhong = x.p.TenPhong,
                LoaiThietBi = x.l.TenLoai,
                ViTriLapDat = x.t.ViTriLapDat,
                TinhTrang = x.t.TinhTrang,
                NgayLapDat = x.t.NgayLap,
                SoLuong = x.t.SoLuong,
                GhiChu = x.t.GhiChu
            }).ToListAsync();
        }

        public async Task<bool> DeleteTonghopmayxuc(int id)
        {
            var mayxuc = await _thietbiDbContext.TongHopMayXucs.FindAsync(id);
            if (mayxuc == null)
            {
                return false;
            }
            _thietbiDbContext.TongHopMayXucs.Remove(mayxuc);
            _thietbiDbContext.SaveChanges();
            return true;
        }

        public async Task<TongHopMayXuc> GetById(int id)
        {
            var mayxuc = await _thietbiDbContext.TongHopMayXucs.FindAsync(id);
            if (mayxuc == null)
            {
                mayxuc = new TongHopMayXuc()
                {
                    Id = 0,
                    LoaiThietBiId = 0,
                    NgayLap = DateTime.Now,
                    SoLuong = 1
                }
                     ;
            }

            return mayxuc;
        }



        public async Task<List<TonghopmayxucVM>> GetTonghopmayxuc()
        {
            var query = from t in _thietbiDbContext.TongHopMayXucs.Include(x => x.MayXuc)
                        select t;
            var TongTB = query.Sum(x => x.SoLuong);
            return await query.Select(x => new TonghopmayxucVM()
            {
                Id = x.Id,
                MaQuanLy = x.MaQuanLy,
                TenMayXuc = x.MayXuc!.TenThietBi,
                TenPhongBan = x.PhongBan!.TenPhong,
                LoaiThietBi = x.LoaiThietBi.TenLoai,
                ViTriLapDat = x.ViTriLapDat,
                NgayLap = x.NgayLap,
                SoLuong = x.SoLuong,
                TinhTrang = x.TinhTrang,
                GhiChu = x.GhiChu,
                TongTB = TongTB
            }).ToListAsync();
        }


        public async Task<PagedResult<TonghopmayxucVM>> GetAllPaging(GetManagerTonghopMayxucPagingRequest request)
        {
            var query = from t in _thietbiDbContext.TongHopMayXucs.Include(x => x.MayXuc).Include(x => x.PhongBan)
                        select t;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.MaQuanLy.Contains(request.Keyword));
            }
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new TonghopmayxucVM()
                {
                    Id = x.Id,
                    MaQuanLy = x.MaQuanLy,
                    TenMayXuc = x.MayXuc.TenThietBi,
                    TenPhongBan = x.PhongBan.TenPhong,
                    LoaiThietBi = x.LoaiThietBi.TenLoai,
                    ViTriLapDat = x.ViTriLapDat,
                    NgayLap = x.NgayLap,
                    SoLuong = x.SoLuong,
                    TinhTrang = x.TinhTrang,
                    GhiChu = x.GhiChu

                }).ToListAsync();
            var pagedResult = new PagedResult<TonghopmayxucVM>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pagedResult;
        }

        public async Task<bool> UpdateTonghopmayxuc([FromBody] MayxucUpdateRequest Request)
        {
            var mayxuc = await _thietbiDbContext.TongHopMayXucs.FindAsync(Request.Id);
            if (mayxuc == null)
            {
                return false;
            }
            mayxuc.Id = Request.Id;
            mayxuc.MaQuanLy = Request.MaQuanLy;
            mayxuc.MayXucId = Request.MayXucId;
            mayxuc.PhongBanId = Request.PhongBanId;
            mayxuc.LoaiThietBiId = Request.LoaiThietBiId;
            mayxuc.ViTriLapDat = Request.ViTriLapDat;
            mayxuc.NgayLap = Request.NgayLap;
            mayxuc.SoLuong = Request.SoLuong;
            mayxuc.TinhTrang = Request.TinhTrang;
            mayxuc.GhiChu = Request.GhiChu;
            _thietbiDbContext.Update(mayxuc);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<int> SumTonghopmayxuc()
        {
            var query =  from s in _thietbiDbContext.TongHopMayXucs
                        select s;
            var sum = await query.SumAsync(x => x.SoLuong);
            return sum;
        }
    }
}
