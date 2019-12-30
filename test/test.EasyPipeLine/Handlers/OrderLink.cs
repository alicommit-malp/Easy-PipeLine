using System;
using System.Threading.Tasks;
using EasyPipeLine;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NUnit.Framework;

namespace test.EasyPipeLine.Handlers
{
    public class OrderLink :Link
    {
        protected override async Task InvokeAsync(ILinkData data)
        {
            
            Test.Logger.LogTrace(nameof(OrderLink));
            
            if(!(data is OrderData order)) throw new ArgumentNullException();
            
            order.State = nameof(OrderLink);
            
            Test.Logger.LogInformation($"State:{nameof(OrderLink)} objectState: " +
                              $"{JsonConvert.SerializeObject(order)}");
            await base.InvokeAsync(order);
        }
    }
}