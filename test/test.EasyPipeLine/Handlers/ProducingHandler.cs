using System;
using EasyPipeLine;
using Newtonsoft.Json;

namespace test.EasyPipeLine.Handlers
{
    public class ProducingHandler : Handler
    {
        protected override void Handle(IHandlerData data)
        {
            if(!(data is OrderData order)) throw new ArgumentNullException();
            order.State = nameof(ProducingHandler);
            
            Console.WriteLine($"State:{nameof(ProducingHandler)} objectState: " +
                              $"{JsonConvert.SerializeObject(order)}");
            base.Handle(order);
        }
        
    }
}