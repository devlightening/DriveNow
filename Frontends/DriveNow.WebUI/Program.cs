var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddLogging();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Alanlar (Areas) için olan rota tanýmýný, varsayýlan rotadan önce tanýmlayýn.
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

// Özel blog detay sayfasý rotasý
app.MapControllerRoute(
    name: "blogDetailSlug",
    pattern: "Blog/BlogDetail/{slug}",
    defaults: new { controller = "Blog", action = "BlogDetail" }
);

// Genel (default) rota tanýmý
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
