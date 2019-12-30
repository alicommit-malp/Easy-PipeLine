using System;
using System.Threading.Tasks;
using EasyPipeLine;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace test.EasyPipeLine.Handlers
{
    public class ExceptionLink : Link
    {
        protected override async Task InvokeAsync(ILinkData data)
        {
            Test.Logger.LogTrace(nameof(ExceptionLink));
            try
            {
                await base.InvokeAsync(data);
            }
            catch (Exception e)
            {
                Test.Logger.LogError(e.Message);
                //handle the exception here 
            }
        }
    }
}