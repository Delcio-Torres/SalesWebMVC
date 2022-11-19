using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Context;
using SalesWebMVC.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SalesWebMvcContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DepartmentService>();

var app = builder.Build();

//Configure the HTTP request pipeline.

app.UseDeveloperExceptionPage();

if (!app.Environment.IsDevelopment())
{
   app.UseExceptionHandler("/Home/Error");
  
   // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
   app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
   var seedService = scope.ServiceProvider.GetService<SeedingService>();

   seedService.Seed();
}

var ptBR = new CultureInfo("pt-BR");
var localizationOptions = new RequestLocalizationOptions
{
   DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("pt-BR"),
   SupportedCultures = new List<CultureInfo> { ptBR },
   SupportedUICultures = new List<CultureInfo> { ptBR }
};

app.UseRequestLocalization(localizationOptions);

app.Run();
