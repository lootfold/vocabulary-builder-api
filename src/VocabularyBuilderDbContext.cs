using Microsoft.EntityFrameworkCore;
using VocabularyBuilderApi.Models;

namespace VocabularyBuilderApi
{
    class VocabularyBuilderDbContext : DbContext
    {
        public VocabularyBuilderDbContext(DbContextOptions<VocabularyBuilderDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}