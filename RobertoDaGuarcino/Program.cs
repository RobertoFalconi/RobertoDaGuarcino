using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();//.AddRazorRuntimeCompilation();

var app = builder.Build();

//app.UseExceptionHandler("/Home/Error");

//app.UseHsts();
//app.UseHttpsRedirection();

app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();

app.Run();