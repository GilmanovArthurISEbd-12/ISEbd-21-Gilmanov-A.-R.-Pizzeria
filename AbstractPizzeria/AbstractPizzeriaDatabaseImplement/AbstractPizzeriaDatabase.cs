using Microsoft.EntityFrameworkCore;
using AbstractPizzeriaDatabaseImplement.Models;

namespace AbstractPizzeriaDatabaseImplement
{
    public class AbstractPizzeriaDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-15DA6KL; Initial Catalog= AbstractPizzeriaDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Ingredient> Ingredients { set; get; }

        public virtual DbSet<Pizza> Pizzas { set; get; }

        public virtual DbSet<PizzaIngredient> PizzaIngredients { set; get; }

        public virtual DbSet<Order> Orders { set; get; }
    }
}