using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleE_CommerceSimulationApp
{
    public class ECommerceContext
    {
        public List<Category> Categories { get; } = new List<Category>();
        public List<Product> Products { get; } = new List<Product>();

        public void Seed()
        {
            var electronic = new Category { Id = 1, Name = "Electronic" };
            var book = new Category { Id = 2, Name = "Book" };
            var clothes = new Category { Id = 3, Name = "Clothes" };


            Categories.AddRange(new[] { electronic, book, clothes });

            Products.AddRange(new[]
            {
                new Product { Id = 1, Name = "Earphones",           Price = 1500m, Stock = 50, CategoryId = electronic.Id },
                new Product { Id = 2, Name = "Mechanical Keyboard",     Price = 2200m, Stock = 30, CategoryId = electronic.Id },
                new Product { Id = 3, Name = "Gaming Mouse",         Price = 900m,  Stock = 40, CategoryId = electronic.Id },

                new Product { Id = 4, Name = "Programming with C#", Price = 350m,  Stock = 20, CategoryId = book.Id },
                new Product { Id = 5, Name = "Algorithm Design", Price = 400m,  Stock = 15, CategoryId = book.Id },

                new Product { Id = 6, Name = "Oversize T-Shirt",   Price = 250m,  Stock = 80, CategoryId = clothes.Id },
                new Product { Id = 7, Name = "Hoodie",             Price = 500m,  Stock = 60, CategoryId = clothes.Id },
            });

        }
    }
}
