using FluentAssertions;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Application.Common.Exceptions;
using NUnit.Framework;
using System;

namespace MyTicketRemaster.Application.UnitTests.Common.Dependencies.DataAccess.Repositories.Common
{
    public class ListQueryModelTests
    {
        [Test]
        public void Instantiation_SetsDefaultValues()
        {
            var sut = new ListQueryModel<int>();

            sut.PageIndex.Should().Be(1);
            sut.PageSize.Should().BeGreaterThan(1);
            sut.OrderBy.Should().Be("id");
            sut.Filter.Should().BeNull();
        }

        [Test]
        public void ThrowFilterIncorrectException_ReturnsFilterValidationError()
        {
            var sut = new ListQueryModel<int>();

            FluentActions.Invoking(()
                => sut.ThrowFilterIncorrectException(new Exception()))
                .Should().ThrowExactly<InputValidationException>()
                .And.Errors.Keys.Should().Contain(nameof(ListQueryModel<int>.Filter));
        }

        [Test]
        public void ThrowOrderByIncorrectException_ReturnsOrderByValidationError()
        {
            var sut = new ListQueryModel<int>();

            FluentActions.Invoking(()
                => sut.ThrowOrderByIncorrectException(new Exception()))
                .Should().ThrowExactly<InputValidationException>()
                .And.Errors.Keys.Should().Contain(nameof(ListQueryModel<int>.OrderBy));
        }
    }
}
