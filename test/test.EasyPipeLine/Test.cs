using System.Threading.Tasks;
using EasyPipeLine;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using test.EasyPipeLine.Handlers;

namespace test.EasyPipeLine
{
    [TestFixture]
    public class Test
    {
        public static ILogger<Test> Logger= TestLogger.Create<Test>();
        
        [Test]
        public async Task Test1()
        {
            var order = new OrderData()
            {
                Name = "Coffee",
                State = "None"
            };
            
            await new Pipeline()
                .Next(new ExceptionLink())
                .Next(new OrderLink())
                .Next(new CheckoutLink())
                .Next(new ProducingLink())
                .Run(order);

            Assert.AreEqual( nameof(ProducingLink),nameof(ProducingLink));
        }
    }
}