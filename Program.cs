using Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebApi.Common;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
var JwtSetting = builder.Configuration.GetSection("JWTSetting");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ThietbiDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ThietbiDb")));
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<ThietbiDbContext>()
                .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = JwtSetting["ValiAudience"],
            ValidIssuer = JwtSetting["ValiIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSetting.GetSection("SecurityKey").Value!))
        };
    });

builder.Services.AddDataProtection()
        .PersistKeysToFileSystem(new DirectoryInfo(@"C:\keys\"));

builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
builder.Services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
builder.Services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
builder.Services.AddTransient<IPhongbanService, PhongbanService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IChucvuService, ChucvuService>();
builder.Services.AddTransient<IDonvitinhService, DonvitinhService>();
builder.Services.AddTransient<ILoaithietbiService, LoaithietbiService>();
builder.Services.AddTransient<ITonghopthietbiService, TonghopthietbiService>();
builder.Services.AddTransient<IStorageService, FileStorageService>();
builder.Services.AddTransient<INhanvienService, NhanvienService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IUserRoleService, UserRoleService>();
builder.Services.AddTransient<IMayXucService, MayXucService>();
builder.Services.AddTransient<ITonghopmayxucService, TonghopmayxucService>();
builder.Services.AddTransient<ICameraService, CameraService>();
builder.Services.AddTransient<ITonghopcameraService, TonghopcameraService>();
builder.Services.AddTransient<IThongsokythuatmayxucService, ThongsokythuatmayxucService>();
builder.Services.AddTransient<INhatkymayxucService, NhatkymayxucService>();
builder.Services.AddTransient<IToitrucService, ToitrucService>();
builder.Services.AddTransient<ITonghoptoitrucService, TonghoptoitrucService>();
builder.Services.AddTransient<INhatkyTonghoptoitrucService, NhatkyTonghoptoitrucService>();
builder.Services.AddTransient<IDanhmuctoitrucService, DanhmuctoitrucService>();
builder.Services.AddTransient<IThongsokythuattoitrucService, ThongsokythuattoitrucService>();
builder.Services.AddTransient<ICapdienService, CapdienService>();
builder.Services.AddTransient<IDanhmucquatgioService, DanhmucquatgioService>();
builder.Services.AddTransient<IThongsoquatgioService, ThongsoquatgioService>();
builder.Services.AddTransient<ITonghopquatgioService, TonghopquatgioService>();
builder.Services.AddTransient<INhatkyquatgioService, NhatkyquatgioService>();
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddHttpsRedirection(option => option.HttpsPort = 5001);
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
});

var app = builder.Build();
//var myOrigins = "_myOrigins";
//builder.Services.AddCors(options => options.AddPolicy(name: myOrigins,
//    policy =>
//    {
//        policy.WithOrigins("http://localhost:5252").AllowAnyMethod().AllowAnyHeader();
//    }
//    ));
// Configure the HTTP request pipeline.
//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Images")),
    RequestPath = new PathString("/wwwroot/Images")
});
app.UseDirectoryBrowser(new DirectoryBrowserOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Images")),
    RequestPath = new PathString("/wwwroot/Images")
});

app.UseRouting();
app.UseCors(options => options.WithOrigins("http://localhost:5252").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseAuthentication();
app.UseAuthorization();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
