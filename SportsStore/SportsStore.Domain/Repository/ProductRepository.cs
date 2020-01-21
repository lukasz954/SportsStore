using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Model;

namespace SportsStore.Domain.Repository
{
    public class ProductRepository: IProductRepository
    {
        public IEnumerable<Product> Products => new List<Product>
        {
            new Product { Name = "Piłka nożna", Price = 25 },
            new Product { Name = "Deska surfingowa", Price = 179 },
            new Product { Name = "Buty do biegania", Price = 95 }
        };
 
    }
}
