using GlameraTaskAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlameraTaskAPI.Presistence.Seeds
{
    public static class ContextSeed
    {
        public static async Task Seed(UserManager<ApplicationDbUser> userManager, ApplicationDbContext applicationDbContext)
        {
            //لو هزود حاجه فى السيد تبقا بالشكل ده
            await CreateBasicUsers(userManager);
            await CreateBasicCategories(applicationDbContext);
            await CreateBasicItems(applicationDbContext);
            await CreateBasicBranches(applicationDbContext);
            await CreateBasicSales(applicationDbContext);
        }

        private static async Task CreateBasicUsers(UserManager<ApplicationDbUser> userManager)
        {
            if (!await userManager.Users.AnyAsync())
            {
                var hasanUser = new ApplicationDbUser
                {
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    UserName = "hasan@domain.com",
                    Email = "hasan@domain.com",
                    NormalizedEmail = "hasan@domain.com",
                    NormalizedUserName = "hasan@domain.com"
                };

                var aliUser = new ApplicationDbUser
                {
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    UserName = "ali@domain.com",
                    Email = "ali@domain.com",
                    NormalizedEmail = "ali@domain.com",
                    NormalizedUserName = "ali@domain.com"
                };

                await userManager.CreateAsync(hasanUser, "123456");
                await userManager.CreateAsync(aliUser, "123456");
            }
        }

        private static async Task CreateBasicCategories(ApplicationDbContext applicationDbContext)
        {
            if (!await applicationDbContext.Categories.AnyAsync())
            {
                try
                {
                    applicationDbContext.Database.OpenConnection();
                    await applicationDbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Categories ON;");
                    await applicationDbContext.Categories.AddRangeAsync(DefaultCategory.BasicCategoryAsync());
                    await applicationDbContext.SaveChangesAsync();
                    await applicationDbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Categories OFF;");
                }
                finally
                {
                    applicationDbContext.Database.CloseConnection();
                }
            }
        }
        private static async Task CreateBasicItems(ApplicationDbContext applicationDbContext)
        {
            if (!await applicationDbContext.Items.AnyAsync())
            {
                try
                {
                    applicationDbContext.Database.OpenConnection();
                    await applicationDbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Items ON;");
                    await applicationDbContext.Items.AddRangeAsync(DefaultItem.BasicItemsAsync());
                    await applicationDbContext.SaveChangesAsync();
                    await applicationDbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Items OFF;");
                }
                finally
                {
                    applicationDbContext.Database.CloseConnection();
                }
            }
        }
        private static async Task CreateBasicBranches(ApplicationDbContext applicationDbContext)
        {
            if (!await applicationDbContext.Branches.AnyAsync())
            {
                try
                {
                    applicationDbContext.Database.OpenConnection();
                    await applicationDbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Branches ON;");
                    await applicationDbContext.Branches.AddRangeAsync(DefaultBranch.BasicBranchAsync());
                    await applicationDbContext.SaveChangesAsync();
                    await applicationDbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Branches OFF;");
                }
                finally
                {
                    applicationDbContext.Database.CloseConnection();
                }
            }
        }
        private static async Task CreateBasicSales(ApplicationDbContext applicationDbContext)
        {
            if (!await applicationDbContext.Sales.AnyAsync())
            {
                try
                {
                    applicationDbContext.Database.OpenConnection();
                    await applicationDbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Sales ON;");
                    await applicationDbContext.Sales.AddRangeAsync(DefaultSale.BasicCategoryAsync());
                    await applicationDbContext.SaveChangesAsync();
                    await applicationDbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Sales OFF;");
                }
                finally
                {
                    applicationDbContext.Database.CloseConnection();
                }
            }
        }
    }
}
