using GlameraTaskAPI.Domain.Entities;
using GlameraTaskAPI.Presistence;
using GlameraTaskAPI.Service.Contract;
using GlameraTaskAPI.Service.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Text;

namespace GlameraTaskAPI.Infrastucture.Extension
{
    public static class ConfigureServiceContainer
    {

        public static void AddDbContextServices(this IServiceCollection services,
             IConfiguration Configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));


        }

        public static void AddLocalizationServices(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("ar"),
                    new CultureInfo("en")
                };

                options.DefaultRequestCulture = new RequestCulture(supportedCultures[1]);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }
        public static void AddDefaultIdentityServices(this IServiceCollection services)
        {

            services.AddDefaultIdentity<ApplicationDbUser>(options =>
            {
                // Default Password settings.
                options.User.RequireUniqueEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            }).AddRoles<IdentityRole>().AddDefaultUI().AddEntityFrameworkStores<ApplicationDbContext>();
        }

        public static void AddTransientServices(this IServiceCollection services)
        {
            services.AddTransient<ISaleService, SaleService>();
        }









    }
}
