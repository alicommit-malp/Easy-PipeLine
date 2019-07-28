using NUnit.Framework;
using test.EasyPipeLine.Handlers;

namespace test.EasyPipeLine
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void Test1()
        {
            var order = new OrderData()
            {
                Name = "Coffee",
                State = "None"
            };

            new OrderHandler()
                .SetRoot()
                .Next(new CheckoutHandler())
                .Next(new ProducingHandler())
                .Run(order);

            Assert.AreEqual( nameof(ProducingHandler),order.State);
        }
    }
}