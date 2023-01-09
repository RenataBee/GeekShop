using GeekShop.Web.Services;
using GeekShop.Web.Services.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependecy Injection
builder.Services.AddMvc();
builder.Services.AddScoped<IProductServiceUI, ProductServiceUI>();

//Mapper
builder.Services.AddHttpClient<IProductServiceUI, ProductServiceUI>(p => 
    p.BaseAddress = new Uri(builder.Configuration["ServicesUrls:ProductAPI"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
