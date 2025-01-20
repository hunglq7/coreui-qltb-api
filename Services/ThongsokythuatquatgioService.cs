using Api.Data.Entites;
using WebApi.Data.EF;

namespace Api.Services
{
    public interface IThongsokythuatquatgioService
    {
        Task<int> Create(ThongsokythuatQuatgio response);
        
    }
    public class ThongsokythuatquatgioService:IThongsokythuatquatgioService
    {
        public readonly ThietbiDbContext _thietbiDbContext;
        public ThongsokythuatquatgioService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext=thietbiDbContext;
            
        }
        public async Task<int> Create(ThongsokythuatQuatgio response)
        {
            if(response==null){
                return 0;
            }
            var items=new ThongsokythuatQuatgio()
            {
                QuatgioId=response.QuatgioId,
                NuocSX=response.NuocSX,
                DuongKinhBanhCT=response.DuongKinhBanhCT,
                SoBanhCT=response.SoBanhCT,
                TocDo=response.TocDo,
                LuuLuong=response.LuuLuong,
                HaAp=response.HaAp,
                CongSuat=response.CongSuat,
                KichThuoc=response.KichThuoc,
                ChieuDai=response.ChieuDai,
                GhiChu=response.GhiChu
            };
            await _thietbiDbContext.ThongsokythuatQuatgios.AddAsync(items);
            var count=_thietbiDbContext.SaveChanges();
            return count;

        }
        
    }
}