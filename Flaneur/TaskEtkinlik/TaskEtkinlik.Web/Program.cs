using Microsoft.AspNetCore.Authentication.Cookies;
using System.Drawing;
using TaskEtkinlik.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region CookieOpt
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => {
//    x.LoginPath = "/member/login";
//    x.Cookie.HttpOnly = true;
//    x.Cookie.SameSite = SameSiteMode.None;
//    x.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
//    x.Cookie.Name = "IdentityCookie";
//    x.ExpireTimeSpan = TimeSpan.FromDays(24);

//    });

//builder.Services.ConfigureApplicationCookie(opt =>
//{
//    opt.Cookie.HttpOnly = true;
//    opt.Cookie.SameSite = SameSiteMode.Strict;
//    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
//    opt.Cookie.Name = "IdentityCookie";
//    opt.ExpireTimeSpan = TimeSpan.FromDays(60);
//    opt.LoginPath = new PathString("Member/Login");


//});
#endregion

builder.Services.AddHttpClient<EventApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddHttpClient<MemberApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddHttpClient<CategoryApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddHttpClient<PlaceApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddHttpClient<BasketTicketApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStatusCodePagesWithReExecute("/Error/Error", "?code={0}");//urle saçma bir adres girince error page'e göndercek
app.UseStaticFiles();


app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();
//app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
