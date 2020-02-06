using SportsStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SportsStore.UnitTests
{
    public class CartTests
    {
        [Fact]
        public void Can_Add_Lines_To_Cart()
        {
            //arrange
            var product1 = new Product { ProductID = 1, Name = "P1" };
            var product2 = new Product { ProductID = 2, Name = "P2" };
            var cart = new Cart();

            //act
            cart.AddItem(product1, 1);
            cart.AddItem(product2, 1);
            var result = cart.Lines.ToArray();

            //assert
            Assert.Equal(2, cart.Lines.Count());
            Assert.Equal(result[0].Product, product1);
            Assert.Equal(result[1].Product, product2);
        }

        [Fact]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            //arrange
            var product1 = new Product { ProductID = 1, Name = "P1" };
            var product2 = new Product { ProductID = 2, Name = "P2" };
            var cart = new Cart();

            //act
            cart.AddItem(product1, 1);
            cart.AddItem(product2, 1);
            cart.AddItem(product1, 10);
            var result = cart.Lines.OrderBy(c => c.Product.ProductID).ToArray();

            //assert
            Assert.Equal(2, cart.Lines.Count());
            Assert.Equal(11, result[0].Quantity);
            Assert.Equal(1, result[1].Quantity);
        }

        [Fact]
        public void Can_Remove_Line()
        {
            //arrange
            var product1 = new Product { ProductID = 1, Name = "P1" };
            var product2 = new Product { ProductID = 2, Name = "P2" };
            var product3 = new Product { ProductID = 3, Name = "P3" };
            var cart = new Cart();
            cart.AddItem(product1, 1);
            cart.AddItem(product2, 3);
            cart.AddItem(product3, 5);
            cart.AddItem(product2, 1);

            //act
            cart.RemoveLine(product2);
            var product2Count = cart.Lines.Where(c => c.Product == product2).Count();

            //assert
            Assert.Equal(0, product2Count);
            Assert.Equal(2, cart.Lines.Count());
        }

        [Fact]
        public void Calculate_Cart_Total()
        {
            //arrange
            var product1 = new Product { ProductID = 1, Name = "P1", Price = 100m };
            var product2 = new Product { ProductID = 2, Name = "P2", Price = 50m };
            var cart = new Cart();

            //act   
            cart.AddItem(product1, 1);
            cart.AddItem(product2, 1);
            cart.AddItem(product1, 3);
            decimal result = cart.ComputeTotalValue();

            //assert   
            Assert.Equal(450M, result);
        }

        [Fact]
        public void Can_Clear_Contents()
        {
            //arrange
            var product1 = new Product { ProductID = 1, Name = "P1", Price = 100m };
            var product2 = new Product { ProductID = 2, Name = "P2", Price = 50m };
            var cart = new Cart();
            cart.AddItem(product1, 1);
            cart.AddItem(product2, 1);

            //act
            cart.Clear();
            var result = cart.Lines.Count();
            //assert
            Assert.Equal(0, result);
        }
    }
}
