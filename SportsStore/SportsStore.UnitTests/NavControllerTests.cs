using Moq;
using SportsStore.Domain.Model;
using SportsStore.Domain.Repository;
using SportsStore.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SportsStore.UnitTests
{
    public class NavControllerTests
    {
        [Fact]
        public void Can_Create_Categories()
        {
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(c => c.Products).Returns(new Product[]
            {
                new Product{ProductID=1,Name="P1",Category="Jabłka" },
                new Product{ProductID=2,Name="P2",Category="Śliwki" },
                new Product{ProductID=3,Name="P3",Category="Jabłka" },
                new Product{ProductID=4,Name="P4",Category="Pomarańcze" },
            });

            var navController = new NavController(mock.Object);
            
            //act
            var result = ((IEnumerable<string>)navController.Menu().Model).ToArray();

            //assert
            Assert.Equal(3,result.Length);
            Assert.Equal("Jabłka", result[0]);
            Assert.Equal("Pomarańcze", result[1]);
            Assert.Equal("Śliwki", result[2]);
        }

        [Fact]
        public void Indicates_Selected_Category()
        {
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(x => x.Products).Returns(new Product[]
            {
                new Product{ProductID=1,Name="P1",Category="Jabłka" },
                new Product{ProductID=4,Name="P4",Category="Pomarańcze" }
            });

            var controller = new NavController(mock.Object);
            string categoryToSelect = "Jabłka";

            //act
            var result = controller.Menu(categoryToSelect).ViewBag.SelectedCategory;

            //assert
            Assert.Equal(result, categoryToSelect);
        }
    }
}
