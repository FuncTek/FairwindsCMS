using FairwindsCMS.Domain.Abstractions;
using FairwindsCMS.Domain.Clients;
using FairwindsCMS.Web.Abstractions;
using FairwindsCMS.Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ICustomerService, CustomerService>(client =>
{
    client.BaseAddress = new("https://my.api.mockaroo.com/customers.json?key=e95894a0");
});

builder.Services.AddTransient<IDataService, DataService>();
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
