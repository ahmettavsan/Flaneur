using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskEtkinlik.Core.Models;
using TaskEtkinlik.Core.Repositories;
using TaskEtkinlik.Core.Services;
using TaskEtkinlik.Core.UnitOfWork;
using TaskEtkinlik.Repository;
using TaskEtkinlik.Repository.Repositories;
using TaskEtkinlik.Repository.UnitOfWork;
using TaskEtkinlik.Service.Mapping;
using TaskEtkinlik.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();///????

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});
builder.Services.ConfigureApplicationCookie(opt =>{
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.None;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "userCookie";
    opt.ExpireTimeSpan = TimeSpan.FromDays(14);
    opt.LoginPath = new PathString("/Member/Login");
});



builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAppUserServices, AppUserServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
