using GlameraTaskAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlameraTaskAPI.Presistence.Seeds
{
    public static class DefaultCategory
    {
        public static List<Category> BasicCategoryAsync()
        {
            return new List<Category>()
            {
                new Category
                {
                    Id = 1,
                    Name = "Food",
                }, new Category
                {
                    Id = 2,
                    Name = "Non-Food",
                }, new Category
                {
                    Id = 3,
                    Name = "Rented",
                }
            };
        }
    }
}
