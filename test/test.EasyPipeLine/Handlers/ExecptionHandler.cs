using System;
using System.Threading.Tasks;
using EasyPipeLine;

namespace test.EasyPipeLine.Handlers
{
    public class ExceptionHandler : Handler
    {
        protected override async Task Handle(IHandlerData data)
        {
            try
            {
                await base.Handle(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //handle the exception here 
            }
        }
    }
}