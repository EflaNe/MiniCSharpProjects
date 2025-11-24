using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SimpleE_CommerceSimulationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ECommerceContext context = new ECommerceContext();
            context.Seed();


            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Simple E-Commerce (Step 1) ===");
                Console.WriteLine("1) List all products");
                Console.WriteLine("2) Filter by category");
                Console.WriteLine("0) Exit");
                Console.Write("Your choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListAllProducts(context);
                        break;
                    case "2":
                        FilterByCategory(context);
                        break;
                    case "0":
                        //
                        break;

                }
            }
        
        }

        private static void FilterByCategory(ECommerceContext context)
        {
            Console.Clear();

            Console.WriteLine();
            int categoryChoose = Convert.ToInt32(Console.ReadLine());
            var filtredCategory = context.Products.Where(p => p.CategoryId == categoryChoose)
                                                  .OrderBy(p => p.Price);

            foreach (var product in filtredCategory)
            {
                Console.WriteLine($"{product}");
            }
        }
        private static void ListAllProducts(ECommerceContext context) 
        {
            var allProducts = context.Products
                                        .OrderBy(x => x.Name);

            foreach (var product in allProducts)
            {
                Console.WriteLine($"Available Products = {product}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
  
    }
   
}
