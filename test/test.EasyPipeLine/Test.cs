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

            await new OrderHandler()
                .SetRoot()
                .Next(new CheckoutHandler())
                .Next(new ProducingHandler())
                .Run(order);

            Assert.AreEqual( nameof(ProducingHandler),order.State);
        }
    }
}