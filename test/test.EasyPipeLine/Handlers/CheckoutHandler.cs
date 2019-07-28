using System;
using EasyPipeLine;
using Newtonsoft.Json;

namespace test.EasyPipeLine.Handlers
{
    public class CheckoutHandler : Handler
    {
        protected override void Handle(IHandlerData data)
        {
            if(!(data is OrderData order)) throw new ArgumentNullException();
            order.State = nameof(CheckoutHandler);
            
            Console.WriteLine($"State:{nameof(CheckoutHandler)} objectState: " +
                              $"{JsonConvert.SerializeObject(order)}");
            base.Handle(order);
        }
    }
}