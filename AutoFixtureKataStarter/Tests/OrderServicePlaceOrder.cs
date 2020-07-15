using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixtureKataStarter;
using AutoFixtureKataStarter.Exceptions;
using AutoFixtureKataStarter.Model;
using AutoFixtureKataStarter.Services;
using Castle.Core.Logging;
using Moq;
using Xunit;

namespace BuilderTestSample.Tests
{
    public class OrderServicePlaceOrder
    {
        private readonly Mock<IFileLogger> _mockLogger = new Mock<IFileLogger>();
        private readonly Fixture _fixture = new Fixture();
        private readonly OrderService _orderService;

        public OrderServicePlaceOrder()
        {
            _fixture.Customize(new AutoMoqCustomization() { ConfigureMembers = true });
            _fixture.Register(() => _mockLogger.Object);
            _orderService = _fixture.Create<OrderService>();
        }

        [Fact]
        public void ThrowsExceptionGivenOrderWithExistingId()
        {
            var order = _fixture.Build<Order>()
                .With(o => o.Id, 123)
                .With(o => o.Customer, _fixture.Build<Customer>()
                                        .Without(c => c.OrderHistory).Create)
                .Create();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));

            _mockLogger.Verify(_ => _.Log(It.IsAny<string>()), "asdf");
        }

    }
}
