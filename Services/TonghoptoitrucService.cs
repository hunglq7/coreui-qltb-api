
using Microsoft.EntityFrameworkCore;
using WebApi.Models.Common;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Tonghoptoitruc;
using WebApi.Models.Tonghopquatgio;
namespace WebApi.Services
{
    public interface ITonghoptoitrucService
    {
        Task<int> Create(TonghoptoitrucCreateRequest request);
        Task<int> Update(TonghoptoitrucUpdateRequest request);
        Task<int> Delete(int id);
        Task<int> SumTonghoptoitruc();
        Task<TongHopToiTruc> GetById(int id);

        Task<PagedResult<TonghoptoitrucVm>> GetAllPaging(GetManagerTonghoptoitrucPagingRequest request);
        Task<List<TonghoptoitrucVm>> GetAll();
    }
    public class TonghoptoitrucService : ITonghoptoitrucService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public TonghoptoitrucService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;

        }

        public async Task<int> Create(TonghoptoitrucCreateRequest request)
        {
            if (request == null)
            {
                return 0;
            }
            var items = new TongHopToiTruc()
            {
                Id = request.Id,
                MaQuanLy = request.MaQuanLy,
                ThietbiId = request.ThietbiId,
                DonViSuDungId = request.DonViSuDungId,
                ViTriLapDat = request.ViTriLapDat,
                NgayLap = request.NgayLap,
                MucDichSuDung = request.MucDichSuDung,
                SoLuong = request.SoLuong,
                TinhTrangThietBi = request.TinhTrangThietBi,
                DuPhong = request.DuPhong,
                GhiChu = request.GhiChu

            };
            await _thietbiDbContext.TongHopToiTrucs.AddAsync(items);
            return await _thietbiDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var query = _thietbiDbContext.TongHopToiTrucs.Find(id);
            if (query == null)
            {
                return 0;
            }
            _thietbiDbContext.TongHopToiTrucs.Remove(query);
            return await _thietbiDbContext.SaveChangesAsync();

        }

        public async Task<List<TonghoptoitrucVm>> GetAll()
        {
            var query = from t in _thietbiDbContext.TongHopToiTrucs.Include(x => x.Danhmuctoitruc).Include(x => x.PhongBan)
                        select t;
            return await query.Select(x => new TonghoptoitrucVm()
            {
                Id = x.Id,
                MaQuanLy = x.MaQuanLy,
                ThietbiId=x.ThietbiId,
                TenThietBi = x.Danhmuctoitruc.TenThietBi,
                PhongBan = x.PhongBan.TenPhong,
                ViTriLapDat = x.ViTriLapDat,
                NgayLap = x.NgayLap,
                MucDichSuDung = x.MucDichSuDung,
                SoLuong = x.SoLuong,
                TinhTrangThietBi = x.TinhTrangThietBi,
                DuPhong = x.DuPhong,
            }).ToListAsync();
        }

        public async Task<PagedResult<TonghoptoitrucVm>> GetAllPaging(GetManagerTonghoptoitrucPagingRequest request)
        {
            var query = from t in _thietbiDbContext.TongHopToiTrucs.Include(x => x.Danhmuctoitruc).Include(x => x.PhongBan)
                        select t;

           if(request.duPhong != null && request.duPhong == true)
            {
                query = query.Where(x => x.DuPhong == request.duPhong);
            }
           else if (request.thietbiId > 0 && request.donviId > 0)
            {
                query = query.Where(x => x.ThietbiId == request.thietbiId && x.DonViSuDungId == request.donviId);
            }
            else if (request.thietbiId > 0 && (request.donviId == 0 || request.donviId == null))
            {
                query = query.Where(x => x.ThietbiId == request.thietbiId);
            }
            else if ((request.thietbiId == 0 || request.thietbiId == null) && request.donviId > 0)
            {
                query = query.Where(x => x.DonViSuDungId == request.donviId);
            }

            int totalRow = await query.CountAsync();
            int sumSoluong = await query.SumAsync(x => x.SoLuong);
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new TonghoptoitrucVm()
                {
                    Id = x.Id,
                    MaQuanLy = x.MaQuanLy,
                    TenThietBi = x.Danhmuctoitruc.TenThietBi,
                    PhongBan = x.PhongBan.TenPhong,
                    ViTriLapDat = x.ViTriLapDat,
                    NgayLap = x.NgayLap,
                    MucDichSuDung = x.MucDichSuDung,
                    SoLuong = x.SoLuong,
                    TinhTrangThietBi = x.TinhTrangThietBi,
                    DuPhong = x.DuPhong,

                }).ToListAsync();
            var pagedResult = new PagedResult<TonghoptoitrucVm>()
            {
                TotalRecords = totalRow,
                SumRecords=sumSoluong,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
                
            };
            return pagedResult;
        }

        public async Task<TongHopToiTruc> GetById(int id)
        {
            var query = await _thietbiDbContext.TongHopToiTrucs.FindAsync(id);
            if (query == null)
            {
                query = new TongHopToiTruc()
                {
                    ThietbiId = 0,
                    DonViSuDungId = 0,
                    NgayLap = new DateTime(),
                    SoLuong = 1

                };

            }
            return query;
        }

        public async Task<int> SumTonghoptoitruc()
        {
            var query = from s in _thietbiDbContext.TongHopToiTrucs
                        select s;
            var sum = await query.SumAsync(x => x.SoLuong);
            return sum;
        }

        public async Task<int> Update(TonghoptoitrucUpdateRequest request)
        {
            var query = _thietbiDbContext.TongHopToiTrucs.Find(request.Id);
            if (query == null)
            {
                return 0;
            }
            query.MaQuanLy = request.MaQuanLy;
            query.ThietbiId = request.ThietbiId;
            query.DonViSuDungId = request.DonViSuDungId;
            query.ViTriLapDat = request.ViTriLapDat;
            query.NgayLap = request.NgayLap;
            query.MucDichSuDung = request.MucDichSuDung;
            query.SoLuong = request.SoLuong;
            query.TinhTrangThietBi = request.TinhTrangThietBi;
            query.DuPhong = request.DuPhong;
            query.GhiChu = request.GhiChu;
            return await _thietbiDbContext.SaveChangesAsync();
        }


    }
}
