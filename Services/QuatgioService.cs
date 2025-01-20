using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Quatgio;

namespace WebApi.Services
{
    public interface IQuatgioService
    {
        Task<int> Create(QuatgioCreateRequest request);
        Task<int> Update(QuatgioUpdateRequest request);
  
        Task<bool> Delete(int id);
        Task<Quatgio> GetById(int id);
        IEnumerable<Quatgio> GetList(string keyword);
        Task<PagedResult<QuatgioVm>> GetAllPaging(GetManageQuatgioPagingRequest request);
            }
    public class QuatgioService : IQuatgioService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public QuatgioService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;

        }
        public async Task<int> Create(QuatgioCreateRequest request)
        {
            if (request == null)
            {
                return 0;
            }

            var quatgio = new Quatgio()
            {
                TenQuat = request.TenQuat,
                LoaiThietBi= request.LoaiThietBi
            };
            await _thietbiDbContext.Quatgios.AddAsync(quatgio);
          var count=  _thietbiDbContext.SaveChanges();
            return count;

        }

        public async Task<bool> Delete(int id)
        {
            var query = await _thietbiDbContext.Quatgios.FindAsync(id);
            if (query == null)
            {
                return false;
            }
            _thietbiDbContext.Quatgios.Remove(query);
            _thietbiDbContext.SaveChanges();
            return true;
        }

        public async Task<PagedResult<QuatgioVm>> GetAllPaging(GetManageQuatgioPagingRequest request)
        {
           
            var query = from t in _thietbiDbContext.Quatgios
                        select t;
            
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.TenQuat.ToLower().Contains(request.Keyword.ToLower()));
            }
            
           
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
               .Take(request.PageSize)
               .Select(x => new QuatgioVm()
               {
                   Id=x.Id,
                   TenQuat=x.TenQuat,
                   LoaiThietBi=x.LoaiThietBi,


               }).ToListAsync();
            var pagedResult = new PagedResult<QuatgioVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<Quatgio> GetById(int id)
        {
            var query = await _thietbiDbContext.Quatgios.FindAsync(id);
            if (query == null)
            {
               query = new Quatgio()
                {
                    Id = 0,
                    TenQuat="",
                    LoaiThietBi=""
                }
                    ;
            }

            return query;
        }

        public IEnumerable<Quatgio> GetList(string keyword)
        {
            IEnumerable<Quatgio> query;
            if (!string.IsNullOrEmpty(keyword))
                query =  _thietbiDbContext.Quatgios.Where(x=>x.TenQuat==keyword).ToList();
            else
                query = _thietbiDbContext.Quatgios;
            return query;
        }

        public async Task<int> Update(QuatgioUpdateRequest request)
        {
            var query = await _thietbiDbContext.Quatgios.FindAsync(request.Id);
            if (query == null)
            {
                return 0;
            }
            query.TenQuat = request.TenQuat;
            query.LoaiThietBi = request.LoaiThietBi;
             _thietbiDbContext.Update(query);
            var count= _thietbiDbContext.SaveChanges();
            return count;

        }
    } 
}
