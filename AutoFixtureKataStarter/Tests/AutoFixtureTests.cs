using AutoFixture;
using AutoFixture.Kernel;
using AutoFixture.Xunit2;
using AutoFixtureKataStarter.Model;
using AutoFixtureKataStarter.Services;
using Moq;
using Xunit;

namespace AutoFixtureKataStarter
{
    /// <summary>
    /// These are provided to show some examples of AutoFixture usage
    /// </summary>
    public class AutoFixtureTests
    {
        private IFixture _fixture;

        public AutoFixtureTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void ExplicitMockOrInstanceUsage()
        {
            var mockLogger = new Mock<IFileLogger>();
            _fixture.Register(() => mockLogger.Object); // add the mock to this fixture

            var orderService = _fixture.Create<OrderService>(); // will use the mockLogger to create

            var order = _fixture.Build<Order>()
                .With(o => o.Id, 0)
                .With(o => o.Customer, _fixture.Build<Customer>()
                                        .Without(c => c.OrderHistory).Create) // AutoFixture doesn't support loops in object hierarchies
                .Create();

            // Act
            orderService.PlaceOrder(order);

            // Assert
            mockLogger.Verify(l => l.Log(It.IsAny<string>()), "OrderService created.");
        }

        [Theory, AutoMoqData]
        public void LogMessage(Order order, [Frozen] Mock<IFileLogger> mockLogger, OrderService sut)
        {
            // This test does the same as the previous test with much less code
            // This is one of the key values of AutoFixture. Try to use this style in your tests for this exercise.

            order.Id = 0; // reset this to 0 so our test passes; otherwise it will have a random int value

            // Act
            sut.PlaceOrder(order); // sut = 'system under test'

            // Assert
            mockLogger.Verify(l => l.Log(It.IsAny<string>()), "OrderService created.");
        }
    }
}
