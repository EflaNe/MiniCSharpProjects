using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleE_CommerceSimulationApp
{
    public class Product
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }

        public override string ToString()
        {
            return $"{Id,-3} | {Name,-20} | {Price,8:C} | Stok: {Stock,3} | CatId: {CategoryId}";
        }
    }
}
