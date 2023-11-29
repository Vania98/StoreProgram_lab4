using Microsoft.EntityFrameworkCore;
using StoreProgram_lab4.Model;

namespace StoreProgram_lab4.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration Entity Basket
            modelBuilder.Entity<Basket>()
                .HasKey(b => b.BasketID);

            modelBuilder.Entity<Basket>()
                .Property(b => b.ClientID)
                .IsRequired();

            modelBuilder.Entity<Basket>()
                .Property(b => b.ProductName)
                .IsRequired()
                .HasMaxLength(15);

            modelBuilder.Entity<Basket>()
                .Property(b => b.Quantity)
                .IsRequired();

            modelBuilder.Entity<Basket>()
                .Property(b => b.Price)
                .IsRequired()
                .HasPrecision(10,2);

            //Foreign Key
            modelBuilder.Entity<Basket>()
            .HasOne(b => b.Client)
            .WithMany()
            .HasForeignKey(b => b.ClientID)
            .OnDelete(DeleteBehavior.Cascade);

            // Configuration Entity Client
            modelBuilder.Entity<Client>()
                .HasKey(c => c.ClientID);

            modelBuilder.Entity<Client>()
                .Property(c => c.ClientName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Client>()
                .Property(c => c.NumberPhone)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}
