using Microsoft.EntityFrameworkCore; // UseSqlServer を使用
using MvcBasicSample.Data; // AppDbContext を使用

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//******
// DefaultConnection という名前の接続文字列を取得する
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("接続文字列がありません");
// AppDbContext を生成するときに使用するSQL Server の接続設定を登録する
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
//******


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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
