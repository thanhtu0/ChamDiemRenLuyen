using TrainingScoring.Data;
using Microsoft.EntityFrameworkCore;
using TrainingScoring.WebUI.AppCodes;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.Business.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using TrainingScoring.Data.Repositories.Implementations;
using TrainingScoring.Data.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using TrainingScoring.DomainModels;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TrainingScoingDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringName"))
);

builder.Services.AddScoped<ILogger<EvaluationFormService>, Logger<EvaluationFormService>>();
//builder.Services.AddScoped<ILogger<TrainingDirectoryService>, Logger<TrainingDirectoryService>>();
//builder.Services.AddScoped<ILogger<TrainingContentService>, Logger<TrainingContentService>>();
//builder.Services.AddScoped<ILogger<TrainingDetailService>, Logger<TrainingDetailService>>();

builder.Services.AddTransient<IEvaluationFormService, EvaluationFormService>();
builder.Services.AddTransient<ITrainingDirectoryService, TrainingDirectoryService>();
builder.Services.AddTransient<ITrainingContentService, TrainingContentService>();
builder.Services.AddTransient<ITrainingDetailService, TrainingDetailService>();

builder.Services.AddTransient<IEvaluationFormRepository, EvaluationFormRepository>();
builder.Services.AddTransient<ITrainingDirectoryRepository, TrainingDirectoryRepository>();
builder.Services.AddTransient<ITrainingContentRepository, TrainingContentRepository>();
builder.Services.AddTransient<ITrainingDetailRepository, TrainingDetailRepository>();
// Add services to the container.
builder.Services.AddHttpContextAccessor();

////Khong su dung thong bao mac dinh cho gia tri Null
builder.Services.AddControllersWithViews()
    .AddMvcOptions(option =>
    {
        option.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
    });

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.Cookie.Name = "AuthenticationCookie";
                    option.LoginPath = "/Account/Login";
                    option.AccessDeniedPath = "/Account/AccessDenied";
                    option.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                });

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(option =>
{
   option.IdleTimeout = TimeSpan.FromMinutes(60);
   option.Cookie.HttpOnly = true;
   option.Cookie.IsEssential = true;
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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Khởi tạo cấu hình cho ApplicationContext
 ApplicationContext.Configure
(
    httpContextAccessor: app.Services.GetRequiredService<IHttpContextAccessor>(),
    hostEnvironment: app.Services.GetService<IWebHostEnvironment>()
);

app.Run();
