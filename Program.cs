using HotelBookingWebApp.Models;
using HotelBookingWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.(MVC �ablonu benimsendi)
builder.Services.AddControllersWithViews();

//geli�tirdi�imiz servisi uygulamaya dahil edelim!(httpClient'e t�r olarak servisimizi verelim)
builder.Services.AddHttpClient<AutoCompleteApiService>();
builder.Services.AddHttpClient<SearchApiService>();

//AutoComplete Endpoint ayarlar�n� uygulamaya dahil edelim!(API)
builder.Services.Configure<AutoCompleteEndpointSetting>(builder.Configuration.GetSection("AutoCompleteApiSettings"));

//Search Endpoint ayarlar�n� uygulamaya dahil edelim!(API)
builder.Services.Configure<SearchEndpointSetting>(builder.Configuration.GetSection("SearchApiSettings"));

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
