using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RpsDbContext
{
    public partial class RpsGameDbContext : DbContext
    {
        public RpsGameDbContext()
        {
        }

        public RpsGameDbContext(DbContextOptions<RpsGameDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Choice> Choices { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Round> Rounds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS04;Database=RpsGameDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Choice>(entity =>
            {
                entity.Property(e => e.ChoiceValue)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.DateAdded)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.GameWinnerNavigation)
                    .WithMany(p => p.GameGameWinnerNavigations)
                    .HasForeignKey(d => d.GameWinner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Games__GameWinne__4D94879B");

                entity.HasOne(d => d.Player1Navigation)
                    .WithMany(p => p.GamePlayer1Navigations)
                    .HasForeignKey(d => d.Player1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Games__Player1__4BAC3F29");

                entity.HasOne(d => d.Player2Navigation)
                    .WithMany(p => p.GamePlayer2Navigations)
                    .HasForeignKey(d => d.Player2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Games__Player2__4CA06362");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(20);

                entity.Property(e => e.Country).HasMaxLength(20);

                entity.Property(e => e.DateAdded)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PlayerFname)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PlayerLname)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.State).HasMaxLength(20);

                entity.Property(e => e.Street).HasMaxLength(20);
            });

            modelBuilder.Entity<Round>(entity =>
            {
                entity.Property(e => e.DateAdded)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Rounds)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rounds__GameId__5812160E");

                entity.HasOne(d => d.Player1ChoiceNavigation)
                    .WithMany(p => p.RoundPlayer1ChoiceNavigations)
                    .HasForeignKey(d => d.Player1Choice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rounds__Player1C__5629CD9C");

                entity.HasOne(d => d.Player2ChoiceNavigation)
                    .WithMany(p => p.RoundPlayer2ChoiceNavigations)
                    .HasForeignKey(d => d.Player2Choice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rounds__Player2C__571DF1D5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
