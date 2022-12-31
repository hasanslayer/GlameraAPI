using GlameraTaskAPI.Domain.Entities;

namespace GlameraTaskAPI.Presistence.Seeds
{
    public static class DefaultItem
    {
        public static List<Item> BasicItemsAsync()
        {
            return new List<Item>()
            {
                new Item
                {
                    Id = 1,
                    Name = "Apple",
                }, new Item
                {
                    Id = 2,
                    Name = "Arial",
                }, new Item
                {
                    Id = 3,
                    Name = "Chair",
                }, new Item
                {
                    Id = 4,
                    Name = "Cake",
                },
            };
        }
    }
}
