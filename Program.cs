using HotelBookingWebApp.Models;
using HotelBookingWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.(MVC �ablonu benimsendi)
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<ApiServices>();

//API ayarlar�n� uygulamaya ekleyelim...
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapDefaultControllerRoute();


app.Run();
