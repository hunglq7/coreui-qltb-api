using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Tonghopcapdien;
using WebApi.Models.TonghopRole;

namespace WebApi.Services
{
    public interface ITonghopRoleService
    {
        // Define methods for the TonghopRoleService here
        Task<bool> Add(TongHopRole role);
        Task<TongHopRole> GetById(int id);
        Task<int> Sum();
        Task<List<TonghopRoleVm>> getDatailById(int id);
        Task<bool> Update([FromBody] TongHopRole Request);
        Task<bool> Delete(int id);
        Task<PagedResult<TonghopRoleVm>> GetAllPaging(TonghopRolePagingRequest request);
    }
    public class TonghopRoleService:ITonghopRoleService
    {
        private readonly ThietbiDbContext _thietbiDb;

        public TonghopRoleService(ThietbiDbContext thietbiDb)
        {
            _thietbiDb = thietbiDb;
        }

        // Implement the methods defined in the interface here
        public async Task<bool> Add(TongHopRole Request)
        {
            if (Request == null)
            {
                return false;
            }
            var items = new TongHopRole()
            {
                Id = Request.Id,
                RoleId= Request.RoleId,
                PhongBanId= Request.PhongBanId,
                ViTriLapDat= Request.ViTriLapDat,
               NgayLap= Request.NgayLap,
               SoLuong= Request.SoLuong,
               TinhTrangThietBi= Request.TinhTrangThietBi,
               DuPhong= Request.DuPhong,
               LamViec= Request.LamViec,
               GhiChu= Request.GhiChu               
            };
            await _thietbiDb.TongHopRoles.AddAsync(items);
            await _thietbiDb.SaveChangesAsync();
            return true;
            
        }

        public async Task<TongHopRole> GetById(int id)
        {
            var query = await _thietbiDb.TongHopRoles.FindAsync(id);
            if (query == null)
            {
                query = new TongHopRole()
                {
                    Id = 0,
                    RoleId=0,
                NgayLap = DateTime.Now,

                }
                     ;
            }

            return query;
        }

        public Task<int> Sum()
        {
            return _thietbiDb.TongHopRoles.CountAsync();
        }

        public async Task<List<TonghopRoleVm>> getDatailById(int id)
        {
            var Query = from t in _thietbiDb.TongHopRoles.Where(x => x.Id == id)
                        join p in _thietbiDb.PhongBans on t.PhongBanId equals p.Id
                        join m in _thietbiDb.DanhMucRoles on t.RoleId equals m.Id


                        select new { t, p, m };
            return await Query.Select(x => new TonghopRoleVm
            {
               Id = x.t.Id,
               TenThietBi = x.m.TenThietBi,
               TenPhong = x.p.TenPhong,
               ViTriLapDat = x.t.ViTriLapDat,
               NgayLap = x.t.NgayLap,
               SoLuong = x.t.SoLuong,
               TinhTrangThietBi = x.t.TinhTrangThietBi,
               DuPhong = x.t.DuPhong,
               LamViec = x.t.LamViec,
               GhiChu = x.t.GhiChu
            }).ToListAsync();
        }

        public async Task<bool> Update([FromBody] TongHopRole Request)
        {
            var entity = await _thietbiDb.TongHopRoles.FindAsync(Request.Id);
            if (entity == null)
            {
                return false;
            }
            entity.Id = Request.Id;
            entity.RoleId = Request.RoleId;
            entity.PhongBanId = Request.PhongBanId;
            entity.ViTriLapDat = Request.ViTriLapDat;
            entity.NgayLap = Request.NgayLap;
            entity.SoLuong = Request.SoLuong;
            entity.TinhTrangThietBi = Request.TinhTrangThietBi;
            entity.DuPhong = Request.DuPhong;
            entity.LamViec = Request.LamViec;
            entity.GhiChu = Request.GhiChu;
            _thietbiDb.Update(entity);
            await _thietbiDb.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var query = await _thietbiDb.TongHopRoles.FindAsync(id);
            if (query == null)
            {
                return false;
            }
            _thietbiDb.TongHopRoles.Remove(query);
            _thietbiDb.SaveChanges();
            return true;
        }

        public Task<PagedResult<TonghopRoleVm>> GetAllPaging(TonghopRolePagingRequest request)
        {
            throw new NotImplementedException();
        }
    }
    
    
}
