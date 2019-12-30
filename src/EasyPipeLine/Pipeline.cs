using System.Threading.Tasks;

namespace EasyPipeLine
{
    public class Pipeline :Link
    {
        public Pipeline()
        {
            IsRoot = true;
        }

        protected override async Task InvokeAsync(ILinkData data)
        {
            await base.InvokeAsync(data);
        }
    }
}