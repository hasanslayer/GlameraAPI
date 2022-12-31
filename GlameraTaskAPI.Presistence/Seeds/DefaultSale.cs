using GlameraTaskAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlameraTaskAPI.Presistence.Seeds
{
    public static class DefaultSale
    {
        public static List<Sale> BasicCategoryAsync()
        {
            return new List<Sale>()
            {
                new Sale
                {
                    Id = 1,
                    Date = new DateTime(2022,01,01),
                    ItemId = 1,
                    Qty = 10,
                    Amount = 100,
                    BranchId = 1,
                    CategoryId = 1,
                },
                new Sale
                {
                    Id = 2,
                    Date = new DateTime(2022,01,01),
                    ItemId = 2,
                    Qty = 5,
                    Amount = 150,
                    BranchId = 1,
                    CategoryId = 2,
                },
                new Sale
                {
                    Id = 3,
                    Date = new DateTime(2022,01,02),
                    ItemId = 3,
                    Qty = 2,
                    Amount = 80,
                    BranchId = 2,
                    CategoryId = 2,
                },
                new Sale
                {
                    Id = 4,
                    Date = new DateTime(2022,01,02),
                    ItemId = 4,
                    Qty = 1,
                    Amount = 40,
                    BranchId = 3,
                    CategoryId = 3,
                },

            };
        }
    }
}
