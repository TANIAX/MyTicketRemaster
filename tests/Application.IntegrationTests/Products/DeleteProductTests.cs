using FluentAssertions;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Application.Products.DeleteProduct;
using MyTicketRemaster.Domain.Products;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MyTicketRemaster.Application.IntegrationTests.Products
{
    public class DeleteProductTests : TestBase
    {
        [Test]
        public void WhenIdIsInvalid_ShouldThrow_EntityNotFoundException()
        {
            var command = new DeleteProductCommand() { Id = 1234567 };

            FluentActions.Invoking(() => TestFramework.SendAsync(command))
                .Should().ThrowAsync<EntityNotFoundException>();
        }

        [Test]
        public async Task WhenIdIsValid_ShouldDeleteProduct()
        {
            var createdProducts = await TestFramework.DataFactory.AddProducts(2);

            // Act.
            await TestFramework.SendAsync(new DeleteProductCommand()
            {
                Id = createdProducts[0].Id
            });

            var deletedProduct = await TestFramework.Data.FindAsync<Product>(createdProducts[0].Id);
            var anotherProduct = await TestFramework.Data.FindAsync<Product>(createdProducts[1].Id);
            var allProducts = await TestFramework.Data.GetAllAsync<Product>();

            deletedProduct.Should().BeNull();
            anotherProduct.Should().NotBeNull();
            allProducts.Should().ContainSingle()
                .And.HaveElementAt(0, anotherProduct);
        }
    }
}
