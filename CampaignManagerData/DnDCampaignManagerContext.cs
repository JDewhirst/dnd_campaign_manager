using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CampaignManagerData
{
    public partial class DnDCampaignManagerContext : DbContext
    {
        public DnDCampaignManagerContext()
        {
        }

        public DnDCampaignManagerContext(DbContextOptions<DnDCampaignManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<RandomEncounter> RandomEncounters { get; set; }
        public virtual DbSet<TerrainDetail> TerrainDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=DnDCampaignManager;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Character>(entity =>
            {
                entity.Property(e => e.CharacterId)
                    .ValueGeneratedNever()
                    .HasColumnName("CharacterID");

                entity.Property(e => e.CharacterDescription)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.CharacterName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.CoordinatesNavigation)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.Coordinates)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Character__Coord__36B12243");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.Coordinates)
                    .HasName("PK__Province__1764066FA4A88ED1");

                entity.Property(e => e.Coordinates).ValueGeneratedNever();

                entity.Property(e => e.HiddenFeature)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.ObviousFeature)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RandEncounterTableId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TerrainId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TerrainID");

                entity.HasOne(d => d.RandEncounterTable)
                    .WithMany(p => p.Provinces)
                    .HasForeignKey(d => d.RandEncounterTableId)
                    .HasConstraintName("FK__Provinces__RandE__33D4B598");

                entity.HasOne(d => d.Terrain)
                    .WithMany(p => p.Provinces)
                    .HasForeignKey(d => d.TerrainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Provinces__Terra__32E0915F");
            });

            modelBuilder.Entity<RandomEncounter>(entity =>
            {
                entity.HasKey(e => e.RandEncounterTableId)
                    .HasName("PK__RandomEn__4E4421BCA6E8210A");

                entity.Property(e => e.RandEncounterTableId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RandEncounter)
                    .HasMaxLength(8000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TerrainDetail>(entity =>
            {
                entity.HasKey(e => e.TerrainId)
                    .HasName("PK__TerrainD__79EED1AF3A5CC519");

                entity.Property(e => e.TerrainId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TerrainID");

                entity.Property(e => e.TerrainDescription)
                    .HasMaxLength(8000)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
