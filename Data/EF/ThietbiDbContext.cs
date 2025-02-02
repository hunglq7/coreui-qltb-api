using Api.Data.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entites;
using WebApi.Data.Extentions;


namespace WebApi.Data.EF
{
    public class ThietbiDbContext: IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ThietbiDbContext(DbContextOptions options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
            //Data seeding
            modelBuilder.Seed();
        }
        public DbSet<PhongBan> PhongBans { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<DonViTinh> DonViTinhs { get; set; }
        public DbSet<LoaiThietBi> LoaiThietBis { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<PhieuXuat> PhieuXuats { get; set; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public DbSet<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
        public DbSet<TongHopThietBi> TongHopThietBis { get; set; }
        public DbSet<TheoDoiSuaChua> TheoDoiSuaChuas { get; set; }
        public DbSet<VatTu> VatTus { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<NhanvienImage> NhanvienImages { get;}
        public DbSet<MayXuc> MayXucs { get; set; }
        public DbSet<TongHopMayXuc> TongHopMayXucs { get;set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<TonghopCamera> TonghopCameras { get; set; }
        public DbSet<NhatkyMayxuc> NhatkyMayxucs { get;set; }
        public DbSet<ThongsokythuatMayxuc> ThongsokythuatMayxucs { get; set; }
        public DbSet<Quatgio> Quatgios { get; set; }
        public DbSet<ThongsokythuatQuatgio> ThongsokythuatQuatgios{get;set;}
        public DbSet<ToiTruc> ToiTrucs { get; set; }

    }
}
