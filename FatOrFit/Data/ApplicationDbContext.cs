using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FatOrFit.Models;

namespace FatOrFit.Data
{
    public class ApplicationDbContext: IdentityDbContext<UserProfile>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Weight> Weights { get; set; }
        public DbSet<Daybook> Daybooks { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<DishInMeal> DishInMeals { get; set; }
        public DbSet<ProductInMeal> ProductInMeals { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishElement> DishElements { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // один пользователь может иметь только один день с определенной датой
            builder.Entity<Daybook>()
                .HasIndex(d => new { d.UserProfileId, d.Date })
                .IsUnique();

            // связь UserProfile с Weights (дневником веса)
            builder.Entity<Weight>()
                .HasOne(w => w.Profile)
                .WithMany(u => u.Weights)
                .HasForeignKey(d => d.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // связь UserProfile с Daybook (дневником питания)
            builder.Entity<Daybook>()
                .HasOne(w => w.Profile)
                .WithMany(u => u.Daybooks)
                .HasForeignKey(d => d.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // связь Daybook с Meal
            builder.Entity<Meal>()
                .HasOne(m => m.Daybook)
                .WithMany(d => d.Meals)
                .HasForeignKey(m => m.DaybookId)
                .OnDelete(DeleteBehavior.Cascade);

            // связь UserProfile с Product
            builder.Entity<Product>()
                .HasOne(w => w.Profile)
                .WithMany(p => p.Products)
                .HasForeignKey(w => w.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // связь UserProfile с Dish
            builder.Entity<Dish>()
                .HasOne(w => w.Profile)
                .WithMany(d => d.Dishes)
                .HasForeignKey(w => w.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);


            // связь Dish с DishElement
            builder.Entity<DishElement>()
                .HasOne(e => e.Dish)
                .WithMany(d => d.Elements)
                .HasForeignKey(e => e.DishId)
                .OnDelete(DeleteBehavior.Cascade);


            // связь Product с DishElement
            builder.Entity<DishElement>()
                .HasOne(e => e.Product)
                .WithMany()
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);


            // связь Meal с ProductInMeal
            builder.Entity<ProductInMeal>()
                .HasOne(p => p.Meal)
                .WithMany(m => m.Products)
                .HasForeignKey(p => p.MealId)
                .OnDelete(DeleteBehavior.Cascade);


            // связь Product с ProductInMeal
            builder.Entity<ProductInMeal>()
                .HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // связь Meal с DishInMeal
            builder.Entity<DishInMeal>()
                .HasOne(p => p.Meal)
                .WithMany(m => m.Dishes)
                .HasForeignKey(p => p.MealId)
                .OnDelete(DeleteBehavior.Cascade);


            // связь Dish с DishInMeal
            builder.Entity<DishInMeal>()
                .HasOne(p => p.Dish)
                .WithMany()
                .HasForeignKey(p => p.DishId)
                .OnDelete(DeleteBehavior.Restrict);




        }

    }
}
