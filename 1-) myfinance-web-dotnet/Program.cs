using myfinance_web_dotnet_infra;
using myfinance_web_dotnet_infra.Interfaces;
using myfinance_web_dotnet_infra.Interfaces.Repositories;
using myfinance_web_dotnet_service;
using myfinance_web_dotnet_service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyFinanceDbContext>();

//Services
builder.Services.AddScoped<IPlanoContaService, PlanoContaService>();
builder.Services.AddScoped<ITransacaoService, TransacaoService>();

//Repositories
builder.Services.AddScoped<IPlanoContaRepository, PlanoContaRepository>();
builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
