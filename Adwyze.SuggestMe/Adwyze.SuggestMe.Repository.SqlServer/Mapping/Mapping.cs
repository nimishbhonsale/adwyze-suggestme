using System.Data.Entity;

namespace Adwyze.SuggestMe.Repository.SqlServer.Mapping
{
    /// <summary>
    /// ORM mapping class
    /// </summary>
    public partial class Mapping : DbContext
    {
        public Mapping()
            : base("name=Mapping")
        {
        }

        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<SearchHistory> SearchHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.SearchHistories)
                .WithOptional(e => e.Profile)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<SearchHistory>()
                .Property(e => e.Keyword)
                .IsUnicode(true);
        }
    }
}
