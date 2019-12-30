using System.Threading.Tasks;

namespace EasyPipeLine
{
    public abstract class Link
    {
        private Link _nextLink;
        private Link _prevLink;
        protected bool IsRoot;

        public Link Next(Link link)
        {
            _nextLink = link;
            _nextLink._prevLink = this;
            return _nextLink;
        }

        public async Task Run(ILinkData data)
        {
            if(IsRoot)
               await InvokeAsync(data);
            else
            {
                _prevLink?.Run(data);
            }
        }

        protected virtual async Task InvokeAsync(ILinkData data)
        {
            if (_nextLink != null) await _nextLink?.InvokeAsync(data);
        }
    }
}