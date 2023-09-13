using FluentAssertions;
using MyTicketRemaster.Application.Products.ProductStockMass;
using MyTicketRemaster.Domain.Common.ValueObjects.Mass;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace MyTicketRemaster.Application.IntegrationTests.Products
{
    class ProductStockMass : TestBase
    {
        [Test]
        public async Task ShouldReturnStockCount()
        {
            var products = await TestFramework.DataFactory.AddProducts(23);

            var result = await TestFramework.SendAsync(new ProductStockMassQuery());

            result.Should().NotBeNull();
            result.Unit.Should().NotBeNull();
            result.Value.Should().Be(
                new Mass(
                    value: products.Sum(x => x.Mass.Value * x.NumberInStock),
                    unit: MassUnit.FromSymbol(products.GroupBy(x => x.Mass.Unit.Symbol).Single().Key)
                ).ConvertTo(
                    MassUnit.FromSymbol(result.Unit))
                .Value
            );             
        }
    }
}
