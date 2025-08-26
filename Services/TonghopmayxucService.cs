﻿using Api.Models.Tonghopmayxuc;
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
                DuPhong = Request.DuPhong

            };
            await _thietbiDbContext.TongHopMayXucs.AddAsync(newmayxuc);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<TonghopmayDetailByIdVm>> getDatailById(int id)
        {
            var query = _thietbiDbContext.TongHopMayXucs
                .Where(t => t.Id == id)
                .Include(t => t.MayXuc)
                .Include(t => t.PhongBan)
                .Include(t => t.LoaiThietBi);

            return await query.Select(t => new TonghopmayDetailByIdVm
            {
                Id = t.Id,
                MaQuanLy = t.MaQuanLy ?? string.Empty,
                TenMay = t.MayXuc != null ? (t.MayXuc.TenThietBi ?? string.Empty) : string.Empty,
                TenPhong = t.PhongBan != null ? (t.PhongBan.TenPhong ?? string.Empty) : string.Empty,
                LoaiThietBi = t.LoaiThietBi != null ? (t.LoaiThietBi.TenLoai ?? string.Empty) : string.Empty,
                ViTriLapDat = t.ViTriLapDat ?? string.Empty,
                TinhTrang = t.TinhTrang ?? string.Empty,
                NgayLapDat = t.NgayLap,
                SoLuong = t.SoLuong,
                DuPhong = t.DuPhong,
                GhiChu = t.GhiChu ?? string.Empty
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
            var safeEntity = await _thietbiDbContext.TongHopMayXucs
                .Where(x => x.Id == id)
                .Select(x => new TongHopMayXuc
                {
                    Id = x.Id,
                    MayXucId = x.MayXucId,
                    PhongBanId = x.PhongBanId,
                    LoaiThietBiId = x.LoaiThietBiId,
                    MaQuanLy = EF.Property<string?>(x, "MaQuanLy") ?? string.Empty,
                    ViTriLapDat = EF.Property<string?>(x, "ViTriLapDat") ?? string.Empty,
                    TinhTrang = EF.Property<string?>(x, "TinhTrang") ?? string.Empty,
                    NgayLap = EF.Property<DateTime?>(x, "NgayLap") ?? DateTime.Now,
                    SoLuong = EF.Property<int?>(x, "SoLuong") ?? 0,
                    DuPhong = EF.Property<bool?>(x, "DuPhong") ?? false,
                    GhiChu = EF.Property<string?>(x, "GhiChu") ?? string.Empty
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (safeEntity == null)
            {
                return new TongHopMayXuc()
                {
                    Id = 0,
                    LoaiThietBiId = 0,
                    NgayLap = DateTime.Now,
                    SoLuong = 1
                };
            }

            return safeEntity;
        }



        public async Task<List<TonghopmayxucVM>> GetTonghopmayxuc()
        {
            var query = from t in _thietbiDbContext.TongHopMayXucs.Include(x => x.MayXuc).Include(x => x.PhongBan).Include(x => x.LoaiThietBi)
                        select t;
            var TongTB = query.Sum(x => x.SoLuong);
            return await query.Select(x => new TonghopmayxucVM()
            {
                Id = x.Id,
                MaQuanLy = x.MaQuanLy ?? string.Empty,
                TenMayXuc = x.MayXuc!.TenThietBi,
                TenPhongBan = x.PhongBan != null ? (x.PhongBan.TenPhong ?? string.Empty) : string.Empty,
                LoaiThietBi = x.LoaiThietBi != null ? (x.LoaiThietBi.TenLoai ?? string.Empty) : string.Empty,
                ViTriLapDat = x.ViTriLapDat ?? string.Empty,
                NgayLap = x.NgayLap,
                SoLuong = x.SoLuong,
                TinhTrang = x.TinhTrang ?? string.Empty,
                DuPhong= x.DuPhong,
                GhiChu = x.GhiChu ?? string.Empty,
                TongTB = TongTB
            }).ToListAsync();
        }


        public async Task<PagedResult<TonghopmayxucVM>> GetAllPaging(GetManagerTonghopMayxucPagingRequest request)
        {
            var query = from t in _thietbiDbContext.TongHopMayXucs
                        .Include(x => x.MayXuc)
                        .Include(x => x.PhongBan)
                        .Include(x => x.LoaiThietBi)
                        select t;        

            // Lọc theo duPhong (nếu có)
            if (request.duPhong.HasValue)
            {
                query = query.Where(x => x.DuPhong == request.duPhong.Value);
            }
            // Lọc theo thietbiId (nếu > 0)
            if (request.thietbiId > 0)
            {
                query = query.Where(x => x.MayXucId == request.thietbiId);
            }
            // Lọc theo donviId (nếu > 0)
            if (request.donviId > 0)
            {
                query = query.Where(x => x.PhongBanId == request.donviId);
            }

            int totalRow = await query.CountAsync();
            int sumSoluong = await query.SumAsync(x => x.SoLuong);
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new TonghopmayxucVM()
                {
                    Id = x.Id,
                    MaQuanLy = x.MaQuanLy ?? string.Empty,
                    TenMayXuc = x.MayXuc!.TenThietBi,
                    TenPhongBan = x.PhongBan != null ? (x.PhongBan.TenPhong ?? string.Empty) : string.Empty,
                    LoaiThietBi = x.LoaiThietBi != null ? (x.LoaiThietBi.TenLoai ?? string.Empty) : string.Empty,
                    ViTriLapDat = x.ViTriLapDat ?? string.Empty,
                    NgayLap = x.NgayLap,
                    SoLuong = x.SoLuong,
                    TinhTrang = x.TinhTrang ?? string.Empty,
                    DuPhong = x.DuPhong,
                    GhiChu = x.GhiChu ?? string.Empty

                }).ToListAsync();
            var pagedResult = new PagedResult<TonghopmayxucVM>()
            {
                SumRecords = sumSoluong,
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
            mayxuc.DuPhong = Request.DuPhong;
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
