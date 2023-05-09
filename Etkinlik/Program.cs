using Business.Abstract;
using Business.Concreate;
using DataAccess.Abstract;
using DataAccess.Concreate;
using Entities.Concreate;
using Entities.Concreate.ViewModels;
using Entitites.Concreate;
using EventUI.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var conString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EventsDbContext>(opt => opt.UseSqlServer(conString));
builder.Services.AddIdentity<User, UserRole>().AddEntityFrameworkStores<EventsDbContext>();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireDigit = true;
    opt.Password.RequireNonAlphanumeric = false;
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/User/Login");
    options.LogoutPath = new PathString("/User/Logout");
    options.AccessDeniedPath = new PathString("/Home/AccessDenied");

    options.Cookie = new()
    {
        Name = "IdentityCookie",
        HttpOnly = true,
        SecurePolicy = CookieSecurePolicy.Always,

    };
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
}
);
builder.Services.AddAuthentication();




builder.Services.AddSession();
builder.Services.AddScoped<IUserService,UserManager>();
builder.Services.AddScoped<IUserDal, EfUserDal>();
builder.Services.AddScoped<ICityService,CityManager>();
builder.Services.AddScoped<ICityDal,EfCityDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<IEventService, EventManager>();
builder.Services.AddScoped<IEventDal, EfEventDal>();
builder.Services.AddScoped<ITicketService, TicketManager>();
builder.Services.AddScoped<ITicketDal, EfTicketDal>();



//builder.Services.AddFluentValidationAutoValidation();
//builder.Services.AddFluentValidation(a => a.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddScoped<IValidator<UserRegisterDTO>, UserValidator>();
builder.Services.AddScoped<IValidator<UserUpdateDTO>, UserUpdateValidator>();
builder.Services.AddScoped<IValidator<UserPasswordUpdateDTO>, UserPasswordUpdateValidator>();
builder.Services.AddScoped<IValidator<EventCreateDTO>, EventCreateValidator>();
builder.Services.AddScoped<IValidator<Event>, EventUpdateValidator>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
