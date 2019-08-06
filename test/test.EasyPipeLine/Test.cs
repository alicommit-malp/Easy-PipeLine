using System.Threading.Tasks;
using NUnit.Framework;
using test.EasyPipeLine.Handlers;

namespace test.EasyPipeLine
{
    [TestFixture]
    public class Test
    {
        [Test]
        public async Task Test1()
        {
            var order = new OrderData()
            {
                Name = "Coffee",
                State = "None"
            };

            await new ExceptionHandler()
                .SetRoot()
                .Next(new OrderHandler())
                .Next(new CheckoutHandler())
                .Next(new ProducingHandler())
                .Run(order);

            Assert.AreEqual( nameof(ProducingHandler),order.State);
        }
    }
}