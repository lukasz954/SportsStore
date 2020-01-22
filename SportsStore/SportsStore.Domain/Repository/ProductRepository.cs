using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.DbService;
using SportsStore.Domain.Model;

namespace SportsStore.Domain.Repository
{
    public class ProductRepository: IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products => context.Products;
 
    }
}
