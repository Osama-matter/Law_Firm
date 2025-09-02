using Law_Firm.Models.dbContext;
using Law_Firm.Reosertiry;
using Law_Firm.Reosertiry.Interface;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.Extensions.Localization;
using System.Reflection;
using Law_Firm;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LawFirmdbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));

// 1. Add localization services
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllersWithViews()
    .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
        {
            var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
            return factory.Create("SharedResource", assemblyName.Name);
        };
    });
// Repositories
builder.Services.AddScoped<IContact, ContactRepostriy>();
builder.Services.AddScoped<Iservicees, ServicesRepositiry>();

// Email Service
builder.Services.AddTransient<EmailService>();
// 2. Configure request localization options
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("ar-EG"),
        new CultureInfo("en-US")
    };

    // Default = ar-EG
    options.DefaultRequestCulture = new RequestCulture("ar-EG");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    // Providers order: QueryString -> Cookie -> Accept-Language
    options.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new QueryStringRequestCultureProvider(),
        new CookieRequestCultureProvider(),
        new AcceptLanguageHeaderRequestCultureProvider()
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// 3. Use request localization middleware early
app.UseRequestLocalization();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

