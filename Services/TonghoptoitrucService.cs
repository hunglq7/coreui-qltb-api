using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.ToiTruc;
using WebApi.Models.Tonghoptoitruc;

namespace WebApi.Services
{
    public interface ITonghoptoitrucService
    {
        Task<int> Create(TonghoptoitrucCreateRequest request);
        Task<int> Update(TonghoptoitrucUpdateRequest request);
        Task<int> Delete(int id);
        Task<TongHopToiTruc> GetById(int id);
        Task<PagedResult<TonghoptoitrucVm>> GetAllPaging(GetManagerTonghoptoitrucPagingRequest request);
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
                GhiChu = request.GhiChu

            };
            await _thietbiDbContext.AddRangeAsync(items);
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

        public async Task<PagedResult<TonghoptoitrucVm>> GetAllPaging(GetManagerTonghoptoitrucPagingRequest request)
        {
            var query = from t in _thietbiDbContext.TongHopToiTrucs.Include(x => x.ToiTruc).Include(x => x.PhongBan)
                        select t;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.MaQuanLy.Contains(request.Keyword));
            }
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new TonghoptoitrucVm()
                {
                    Id = x.Id,
                    MaQuanLy = x.MaQuanLy,
                    TenThietBi = x.ToiTruc.MaHieu,
                    PhongBan = x.PhongBan.TenPhong,
                    ViTriLapDat = x.ViTriLapDat,
                    NgayLap = x.NgayLap,
                    MucDichSuDung = x.MucDichSuDung,
                    SoLuong = x.SoLuong,
                    TinhTrangThietBi = x.TinhTrangThietBi,

                }).ToListAsync();
            var pagedResult = new PagedResult<TonghoptoitrucVm>()
            {
                TotalRecords = totalRow,
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
                    NgayLap = new DateTime()
                };

            }
            return query;
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
            query.GhiChu = request.GhiChu;
            return await _thietbiDbContext.SaveChangesAsync();
        }


    }
}
