using GlameraTaskAPI.Domain.Entities;

namespace GlameraTaskAPI.Presistence.Seeds
{
    public static class DefaultBranch
    {
        public static List<Branch> BasicBranchAsync()
        {
            return new List<Branch>()
            {
                new Branch
                {
                    Id = 1,
                    Name = "Cairo",
                }, new Branch
                {
                    Id = 2,
                    Name = "Alex",
                }, new Branch
                {
                    Id = 3,
                    Name = "Tanta",
                }
            };
        }
    }
}
