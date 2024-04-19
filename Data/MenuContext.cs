using Menu.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId
            });

            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngredient>().HasOne(i => i.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i => i.IngredientId);

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Capricciosa", Price = 7, ImageURL = "https://www.buttalapasta.it/wp-content/uploads/2017/11/pizza-capricciosa.jpg" },
                new Dish { Id = 2, Name = "Pepperoni", Price = 6, ImageURL = "https://www.moulinex-me.com/medias/?context=bWFzdGVyfHJvb3R8MTQzNTExfGltYWdlL2pwZWd8aGNlL2hmZC8xNTk2ODYyNTc4NjkxMC5qcGd8MmYwYzQ4YTg0MTgzNmVjYTZkMWZkZWZmMDdlMWFlMjRhOGIxMTQ2MTZkNDk4ZDU3ZjlkNDk2MzMzNDA5OWY3OA" },
                new Dish { Id = 3, Name = "Margherita", Price = 5, ImageURL = "https://images.ctfassets.net/nw5k25xfqsik/64VwvKFqxMWQORE10Tn8pY/200c0538099dc4d1cf62fd07ce59c2af/20220211142754-margherita-9920.jpg?w=1024" },
                new Dish { Id = 4, Name = "Quattro Stagioni", Price = 10, ImageURL = "https://i.redd.it/6xsma5ni08i61.jpg" },
                new Dish { Id = 5, Name = "Vegetariana", Price = 6.5, ImageURL = "https://images.arla.com/recordid/F67E678C-299C-46E8-B52D14612437E31D/vegetable-pizza.jpg?width=1200&height=630&mode=crop&format=jpg" },
                new Dish { Id = 6, Name = "Quattro Formaggi", Price = 8, ImageURL = "https://www.italianstylecooking.net/wp-content/uploads/2020/04/Pizza-quattro-formaggi-neu.jpg" }
                );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Tomato Sauce" },
                new Ingredient { Id = 2, Name = "Mozzarella" },
                new Ingredient { Id = 3, Name = "Ham" },
                new Ingredient { Id = 4, Name = "Mushrooms" },
                new Ingredient { Id = 5, Name = "Olives" },
                new Ingredient { Id = 6, Name = "Pepperoni" },
                new Ingredient { Id = 7, Name = "Basil" },
                new Ingredient { Id = 8, Name = "Paprika" },
                new Ingredient { Id = 9, Name = "Gorgonzola" },
                new Ingredient { Id = 10, Name = "Parmigiano" },
                new Ingredient { Id = 11, Name = "Edam" }
                );
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredientId = 1 },
                new DishIngredient { DishId = 1, IngredientId = 2 },
                new DishIngredient { DishId = 1, IngredientId = 3 },
                new DishIngredient { DishId = 1, IngredientId = 4 },
                new DishIngredient { DishId = 1, IngredientId = 5 },

                new DishIngredient { DishId = 2, IngredientId = 1 },
                new DishIngredient { DishId = 2, IngredientId = 6 },
                new DishIngredient { DishId = 2, IngredientId = 11 },

                new DishIngredient { DishId = 3, IngredientId = 1 },
                new DishIngredient { DishId = 3, IngredientId = 2 },
                new DishIngredient { DishId = 3, IngredientId = 7 },

                new DishIngredient { DishId = 4, IngredientId = 1 },
                new DishIngredient { DishId = 4, IngredientId = 2 },
                new DishIngredient { DishId = 4, IngredientId = 3 },
                new DishIngredient { DishId = 4, IngredientId = 4 },
                new DishIngredient { DishId = 4, IngredientId = 5 },
                new DishIngredient { DishId = 4, IngredientId = 6 },
                new DishIngredient { DishId = 4, IngredientId = 7 },
                new DishIngredient { DishId = 4, IngredientId = 8 },
                new DishIngredient { DishId = 4, IngredientId = 9 },
                new DishIngredient { DishId = 4, IngredientId = 10 },
                new DishIngredient { DishId = 4, IngredientId = 11 },

                new DishIngredient { DishId = 5, IngredientId = 1 },
                new DishIngredient { DishId = 5, IngredientId = 4 },
                new DishIngredient { DishId = 5, IngredientId = 5 },
                new DishIngredient { DishId = 5, IngredientId = 7 },
                new DishIngredient { DishId = 5, IngredientId = 8 },
                new DishIngredient { DishId = 5, IngredientId = 11 },

                new DishIngredient { DishId = 6, IngredientId = 1 },
                new DishIngredient { DishId = 6, IngredientId = 2 },
                new DishIngredient { DishId = 6, IngredientId = 9 },
                new DishIngredient { DishId = 6, IngredientId = 10 },
                new DishIngredient { DishId = 6, IngredientId = 11 }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}