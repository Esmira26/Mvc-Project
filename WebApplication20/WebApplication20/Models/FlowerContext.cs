//"Server=wdb4.my-hosting-panel.com;Database=nurlans1_kharibulbul; UserId=nurlans1_kharibulbul; Password=3Ug0f5s#6"

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication20.Models;

public partial class FlowerContext : DbContext
{
    public FlowerContext()
    {
    }

    public FlowerContext(DbContextOptions<FlowerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Catdirilma> Catdirilmas { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Elaqe> Elaqes { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Lofe> Loves { get; set; }

    public virtual DbSet<Mehsul> Mehsuls { get; set; }

    public virtual DbSet<Musteri> Musteris { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Sebet> Sebets { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }

    public virtual DbSet<Telefon> Telefons { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-PNGVQ34\\SQLEXPRESS;Database=Flower;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Catdirilma>(entity =>
        {
            entity.HasKey(e => e.CatdirilmaId).HasName("PK__Catdiril__20C042867FB46BF9");

            entity.ToTable("Catdirilma");

            entity.Property(e => e.CatdirilmaAd).HasMaxLength(80);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0B01770711");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<Elaqe>(entity =>
        {
            entity.HasKey(e => e.ElaqeId).HasName("PK__Elaqe__BABE12C8719EC464");

            entity.ToTable("Elaqe");

            entity.Property(e => e.ElaqeAd)
                .HasMaxLength(50)
                .HasColumnName("ELaqeAd");
            entity.Property(e => e.ElaqeMail).HasMaxLength(80);
            entity.Property(e => e.ElaqeTel).HasMaxLength(120);
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PK__Gender__4E24E9F7C746E5D7");

            entity.ToTable("Gender");

            entity.Property(e => e.GenderName).HasMaxLength(50);
        });

        modelBuilder.Entity<Lofe>(entity =>
        {
            entity.HasKey(e => e.LoveId).HasName("PK__Loves__37F02A1E80EF6ED3");

            entity.HasOne(d => d.LoveMehsul).WithMany(p => p.Loves)
                .HasForeignKey(d => d.LoveMehsulId)
                .HasConstraintName("FK__Loves__LoveMehsu__6FE99F9F");

            entity.HasOne(d => d.LoveUser).WithMany(p => p.Loves)
                .HasForeignKey(d => d.LoveUserId)
                .HasConstraintName("FK__Loves__LoveUserI__70DDC3D8");
        });

        modelBuilder.Entity<Mehsul>(entity =>
        {
            entity.HasKey(e => e.MehsulId).HasName("PK__Mehsuls__6F26B22B4F73FA2D");

            entity.Property(e => e.MehsulAd).HasMaxLength(60);
            entity.Property(e => e.MehsulLove).HasMaxLength(90);
            entity.Property(e => e.MehsulSekil).HasMaxLength(100);
            entity.Property(e => e.MehsulStatus).HasMaxLength(50);
            entity.Property(e => e.MehsulunKodu).HasMaxLength(50);

            entity.HasOne(d => d.MehsulCategory).WithMany(p => p.Mehsuls)
                .HasForeignKey(d => d.MehsulCategoryId)
                .HasConstraintName("FK__Mehsuls__MehsulC__398D8EEE");

            entity.HasOne(d => d.MehsulSubCategory).WithMany(p => p.Mehsuls)
                .HasForeignKey(d => d.MehsulSubCategoryId)
                .HasConstraintName("FK__Mehsuls__MehsulS__59063A47");
        });

        modelBuilder.Entity<Musteri>(entity =>
        {
            entity.HasKey(e => e.MusteriId).HasName("PK__Musteri__726247910645CF95");

            entity.ToTable("Musteri");

            entity.Property(e => e.MusteriAd).HasMaxLength(60);
            entity.Property(e => e.MusteriKartTarixi).HasMaxLength(90);
            entity.Property(e => e.MusteriKarti).HasMaxLength(90);
            entity.Property(e => e.MusteriTel).HasMaxLength(120);

            entity.HasOne(d => d.MusteriCatdirilma).WithMany(p => p.Musteris)
                .HasForeignKey(d => d.MusteriCatdirilmaId)
                .HasConstraintName("FK__Musteri__Musteri__5812160E");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("PK__Photo__21B7B5E2D4CA11CC");

            entity.ToTable("Photo");

            entity.HasOne(d => d.PhotoMehsul).WithMany(p => p.Photos)
                .HasForeignKey(d => d.PhotoMehsulId)
                .HasConstraintName("FK__Photo__PhotoMehs__6D0D32F4");
        });

        modelBuilder.Entity<Sebet>(entity =>
        {
            entity.HasKey(e => e.SebetId).HasName("PK__Sebet__6571914ED15DA0C7");

            entity.ToTable("Sebet");

            entity.HasOne(d => d.SebetMehsul).WithMany(p => p.Sebets)
                .HasForeignKey(d => d.SebetMehsulId)
                .HasConstraintName("FK__Sebet__SebetMehs__534D60F1");

            entity.HasOne(d => d.SebetUser).WithMany(p => p.Sebets)
                .HasForeignKey(d => d.SebetUserId)
                .HasConstraintName("FK__Sebet__SebetUser__6477ECF3");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__C8EE20637C95507C");

            entity.ToTable("Status");

            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.HasKey(e => e.SubCategoryId).HasName("PK__SubCateg__26BE5B19C36EACDE");

            entity.ToTable("SubCategory");

            entity.Property(e => e.SubCategoryName).HasMaxLength(100);

            entity.HasOne(d => d.SubCategoryCategory).WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.SubCategoryCategoryId)
                .HasConstraintName("FK__SubCatego__SubCa__3C69FB99");
        });

        modelBuilder.Entity<Telefon>(entity =>
        {
            entity.HasKey(e => e.TelefonId).HasName("PK__Telefon__5AB2226574185281");

            entity.ToTable("Telefon");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CE27D5B53");

            entity.Property(e => e.UserEmail).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(30);
            entity.Property(e => e.UserPassword).HasMaxLength(80);

            entity.HasOne(d => d.UserStatus).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserStatusId)
                .HasConstraintName("FK__Users__UserStatu__73BA3083");

            entity.HasOne(d => d.UserTelefon).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTelefonId)
                .HasConstraintName("FK__Users__UserTelef__6754599E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
