using GlameraTaskAPI.Domain.Entities;
using GlameraTaskAPI.Infrastucture.Extension;
using GlameraTaskAPI.Infrastucture.Middleware;
using GlameraTaskAPI.Presistence;
using GlameraTaskAPI.Presistence.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddDefaultIdentityServices();
builder.Services.AddDbContextServices(builder.Configuration);
builder.Services.AddLocalizationServices();
builder.Services.AddTransientServices();
builder.Services.AddRazorPages();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<ApplicationDbUser>>();
    var applicationDbContext = services.GetRequiredService<ApplicationDbContext>();
    await ContextSeed.Seed(userManager, applicationDbContext);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseExceptionHandler(err => err.UseCustomErrors(app.Environment));
}


var supportedCultures = new[] { new CultureInfo("ar"), new CultureInfo("en") };
supportedCultures[0].DateTimeFormat = supportedCultures[1].DateTimeFormat;

var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(supportedCultures[1]),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    RequestCultureProviders = new List<IRequestCultureProvider>()
                {
                    // Order is important, its in which order they will be evaluated
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider(),
                }
};

app.UseRequestLocalization(localizationOptions);

app.UseHttpsRedirection();
app.UseCors();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
