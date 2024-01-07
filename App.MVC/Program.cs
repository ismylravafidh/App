using App.Business.Mappers;
using App.Business.Services.Implementations;
using App.Business.Services.Interfaces;
using App.Business.ViewModels.BlogVms;
using App.DAL.Common;
using App.DAL.Repository.Implementations;
using App.DAL.Repository.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogService, BlogService>();

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
builder.Services.AddControllersWithViews().AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssembly(typeof(BlogCreateVmValidation).Assembly);
    opt.RegisterValidatorsFromAssembly(typeof(BlogUpdateVmValidation).Assembly);
});


builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
            name: "Manage",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );


app.UseStaticFiles();


app.Run();
