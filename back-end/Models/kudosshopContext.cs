using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KudosShop.Models
{
    public partial class kudosshopContext : DbContext
    {
        public kudosshopContext()
        {
        }

        public kudosshopContext(DbContextOptions<kudosshopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminAction> AdminActions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<TestView> TestViews { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserKudosInfo> UserKudosInfos { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:visma-hackathon2021.database.windows.net,1433;Database=kudos-shop;Trusted_Connection=False;User ID=visma-admin;Password=kBK@GWNd5jcJ43p;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdminAction>(entity =>
            {
                entity.HasKey(e => e.OperationId);

                entity.Property(e => e.OperationId).HasColumnName("operation_id");

                entity.Property(e => e.OperationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("operation_date");

                entity.Property(e => e.OperationDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("operation_description");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AdminActions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminActions_Users");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductComment)
                    .HasMaxLength(500)
                    .HasColumnName("product_comment");

                entity.Property(e => e.ProductImage)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("product_image");

                entity.Property(e => e.ProductIsAvailable).HasColumnName("product_isAvailable");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductPrice).HasColumnName("product_price");
            });

            modelBuilder.Entity<TestView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("test_view");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("reason");

                entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");

                entity.Property(e => e.SendersId).HasColumnName("senders_id");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("transaction_date");

                entity.Property(e => e.TransactionType).HasColumnName("transaction_type");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Transactions_Product");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.TransactionReceivers)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_Receiving_User");

                entity.HasOne(d => d.Senders)
                    .WithMany(p => p.TransactionSenders)
                    .HasForeignKey(d => d.SendersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_Senders_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserSurname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("user_surname");

                entity.Property(e => e.UserType).HasColumnName("user_type");

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_User_types");
            });

            modelBuilder.Entity<UserKudosInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("user_kudos_info");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserSurname)
                    .HasMaxLength(50)
                    .HasColumnName("user_surname");

                entity.Property(e => e.UserType).HasColumnName("user_type");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("User_types");

                entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");

                entity.Property(e => e.UserType1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("user_type")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
