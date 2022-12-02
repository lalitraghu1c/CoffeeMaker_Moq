using CoffeeMaker_Moq;
using Moq;

namespace CoffeeMakerTest
{
    public class Tests
    {

        [Test]
        public void OrderACoffee_Should_Return_Recive_Message()
        {
            StarbuckStore store = new StarbuckStore(new FakeStarbucks());
            string result = store.OrderCoffee(2, 4);
            Assert.AreEqual("Your Order is recieved", result);

        }
        [Test]
        public void OrderACoffee1_Should_Return_Recieve_Message()
        {
            StarbuckStore store = new StarbuckStore(new StubStarbucks());
            string result = store.OrderCoffee(2, 4);
            Assert.AreEqual("Your Order is recieved", result);
        }
        [Test]
        public void OrderACoffee_Should_Return_Recieve_MessageUsingMock()
        {
            var service = new Mock<IMakeACoffee>();
            service.Setup(x => x.CheckIngridentAvailablity()).Returns(true);
            service.Setup(x => x.CoffeeMaking(It.IsAny<int>(), It.IsAny<int>())).Returns("Your Order is recieved");
            var store = new StarbuckStore(service.Object);
            var result = store.OrderCoffee(2, 4);
            Assert.AreEqual("Your Order is recieved", result);
        }
    }
}