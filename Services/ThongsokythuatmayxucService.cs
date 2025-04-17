using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.ThongsokythuatMayXuc;
using WebApi.Models.ThongsoQuatgio;

namespace WebApi.Services
{
    public interface IThongsokythuatmayxucService
    {
        Task<List<ThongsokythuatmayxucVm>> GetAll();
        Task<PagedResult<ThongsokythuatmayxucVm>> GetAllPaging(ThongsomayxucPagingRequest request);
        Task<ThongsokythuatMayxuc> GetById(int id);
        Task<List<ThongsokythuatMayxucDetailByIdVm>> getDatailById(int id);
        Task<bool> Add([FromBody] ThongsokythuatEdit Request);
        Task<bool> Update([FromBody] ThongsokythuatEdit Request);
        Task<bool> Delete(int id);
    }
    public class ThongsokythuatmayxucService : IThongsokythuatmayxucService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public ThongsokythuatmayxucService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<bool> Add([FromBody] ThongsokythuatEdit Request)
        {
            if (Request == null)
            {
                return false;
            }

            var newItems = new ThongsokythuatMayxuc()
            {
                Id = Request.Id,
                MayXucId = Request.MayXucId,
                NoiDung = Request.NoiDung,
                DonViTinh = Request.DonViTinh,
                ThongSo = Request.ThongSo,

            };
            await _thietbiDbContext.ThongsokythuatMayxucs.AddAsync(newItems);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var items = await _thietbiDbContext.ThongsokythuatMayxucs.FindAsync(id);
            if (items == null)
            {
                return false;
            }
            _thietbiDbContext.ThongsokythuatMayxucs.Remove(items);
            _thietbiDbContext.SaveChanges();
            return true;
        }

        public async Task<List<ThongsokythuatmayxucVm>> GetAll()
        {
            var query = from t in _thietbiDbContext.ThongsokythuatMayxucs.Include(x => x.MayXuc)
                        select t;
            return await query.Select(x => new ThongsokythuatmayxucVm()
            {
                Id = x.Id,
                TenThietBi = x.MayXuc.TenThietBi,
                NoiDung = x.NoiDung,
                DonViTinh = x.DonViTinh,
                ThongSo = x.ThongSo,
            }).ToListAsync();
        }

        public async Task<PagedResult<ThongsokythuatmayxucVm>> GetAllPaging(ThongsomayxucPagingRequest request)
        {
            var query = from t in _thietbiDbContext.ThongsokythuatMayxucs.Include(x => x.MayXuc)
                        select t;
            if (request.thietbiId > 0)
            {
                query = query.Where(x => x.MayXucId == request.thietbiId);
            }


            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ThongsokythuatmayxucVm()
                {
                    Id = x.Id,
                    TenThietBi = x.MayXuc.TenThietBi,
                    NoiDung = x.NoiDung,
                    DonViTinh = x.DonViTinh,
                    ThongSo = x.ThongSo,

                }).ToListAsync();
            var pagedResult = new PagedResult<ThongsokythuatmayxucVm>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pagedResult;
        }

        public async Task<ThongsokythuatMayxuc> GetById(int id)
        {
            var items = await _thietbiDbContext.ThongsokythuatMayxucs.FindAsync(id);
            if (items == null)
            {
                items = new ThongsokythuatMayxuc()
                {
                    Id = 0,
                    MayXucId = 1,
                    NoiDung = "",
                    DonViTinh = "",
                    ThongSo = ""
                }
                     ;
            }

            return items;
        }

        public async Task<List<ThongsokythuatMayxucDetailByIdVm>> getDatailById(int id)
        {
            var Query = from t in _thietbiDbContext.ThongsokythuatMayxucs.Where(x => x.MayXucId == id)
                        join m in _thietbiDbContext.MayXucs on t.MayXucId equals m.Id


                        select new { t, m };
            return await Query.Select(x => new ThongsokythuatMayxucDetailByIdVm
            {
                Id = x.t.Id,
                TenThietBi = x.m.TenThietBi,
                NoiDung = x.t.NoiDung,
                DonViTinh = x.t.DonViTinh,
                ThongSo = x.t.ThongSo,
            }).ToListAsync();
        }

        public async Task<bool> Update([FromBody] ThongsokythuatEdit Request)
        {
            var items = await _thietbiDbContext.ThongsokythuatMayxucs.FindAsync(Request.Id);
            if (items == null)
            {
                return false;
            }
            items.Id = Request.Id;
            items.MayXucId = Request.MayXucId;
            items.NoiDung = Request.NoiDung;
            items.DonViTinh = Request.DonViTinh;
            items.ThongSo = Request.ThongSo;
            _thietbiDbContext.Update(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
    }
}
