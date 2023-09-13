using FluentAssertions;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Application.Products.CreateProduct;
using MyTicketRemaster.Domain.Products;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MyTicketRemaster.Application.IntegrationTests.Products
{
    public class CreateProductTests : TestBase
    {
        [Test]
        public void WhenDtoIsBlank_ShouldThrow_InputValidationException()
        {
            FluentActions.Invoking(() => TestFramework.SendAsync(new CreateProductCommand()))
                .Should().ThrowExactlyAsync<InputValidationException>();
        }

        [Test]
        public async Task WhenDtoIsValid_ShouldCreateProduct()
        {
            var command = new CreateProductCommand()
            {
                Name = "Product",
                Description = "Description",
                MassUnitSymbol = "kg",
                MassValue = 10.1f,
                PriceAmount = 99.99m,
                PriceCurrencyCode = "USD"
            };

            var productId = await TestFramework.SendAsync(command);

            var createdProduct = await TestFramework.Data.FindAsync<Product>(productId);
            createdProduct.Should().NotBeNull();
            createdProduct.Id.Should().Be(productId);
            createdProduct.NumberInStock.Should().Be(0);
            createdProduct.Name.Should().Be(command.Name);
            createdProduct.Description.Should().Be(command.Description);
            createdProduct.Mass.Value.Should().Be(command.MassValue);
            createdProduct.Mass.Unit.Symbol.Should().Be(command.MassUnitSymbol);
            createdProduct.Price.Amount.Should().Be(command.PriceAmount);
            createdProduct.Price.Currency.Code.Should().Be(command.PriceCurrencyCode);
        }
    }
}
