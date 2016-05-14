using mbs.cardlandia.baseabstractions.datalayer.Entities;

namespace mbs.cardlandia.userprofile.datalayer.Entities {
    using System.Data.Entity;
    
    public partial class UserProfileModel : BaseEntityFactory {
        public UserProfileModel()
            : base("name=UserProfileModel") {
        }

        public virtual DbSet<Card> Cards { get; set; }

        public virtual DbSet<CardType> CardTypes { get; set; }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<Players2Cards> Players2Cards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Card>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Card>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Card>()
                .HasMany(e => e.Players2Cards)
                .WithRequired(e => e.Card)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CardType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CardType>()
                .HasMany(e => e.Cards)
                .WithRequired(e => e.CardType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.DisplayName)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .HasMany(e => e.Players2Cards)
                .WithRequired(e => e.Player)
                .WillCascadeOnDelete(false);
        }
    }
}