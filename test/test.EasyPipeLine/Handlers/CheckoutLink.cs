using System;
using System.Threading.Tasks;
using EasyPipeLine;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NUnit.Framework;

namespace test.EasyPipeLine.Handlers
{
    public class CheckoutLink : Link
    {
        protected override async Task InvokeAsync(ILinkData data)
        {
            Test.Logger.LogTrace(nameof(CheckoutLink));
            
            if(!(data is OrderData order)) throw new ArgumentNullException();
            order.State = nameof(CheckoutLink);
            
            Test.Logger.LogInformation($"State:{nameof(CheckoutLink)} objectState: " +
                              $"{JsonConvert.SerializeObject(order)}");
            await base.InvokeAsync(order);
        }
    }
}