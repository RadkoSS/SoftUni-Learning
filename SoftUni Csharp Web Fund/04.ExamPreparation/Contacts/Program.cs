using Microsoft.EntityFrameworkCore;

using Contacts.Data;
using Contacts.Data.Models.User;
using Contacts.Services;
using Contacts.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ContactsDbContext>(options =>
    options.UseSqlServer(connectionString).UseLazyLoadingProxies());

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.Password.RequireUppercase = false;
    //options.SignIn.RequireConfirmedPhoneNumber = false;
    //options.Password.RequireLowercase = false;
    //options.Password.RequireNonAlphanumeric = false;
    //options.Password.RequiredUniqueChars = 0;
})
.AddEntityFrameworkStores<ContactsDbContext>();

builder.Services.AddScoped<IContactsService, ContactsService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();