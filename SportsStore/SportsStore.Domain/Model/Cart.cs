using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Model
{
    public class Cart
    {
        private List<CartLine> cartLines = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine line = cartLines.Where(x => x.Product.ProductID == product.ProductID).FirstOrDefault();

            if (line == null)
                cartLines.Add(new CartLine { Product = product, Quantity = quantity });
            else
                line.Quantity += quantity;
        }

        public void RemoveLine(Product product) => cartLines.RemoveAll(x => x.Product.ProductID == product.ProductID);

        public decimal ComputeTotalValue() => cartLines.Sum(x => x.Product.Price * x.Quantity);

        public void Clear() => cartLines.Clear();

        public IEnumerable<CartLine> Lines => cartLines;
    }
}
