using System.Threading.Tasks;

namespace EasyPipeLine
{
    public abstract class Handler
    {
        private Handler _nextHandler;
        private Handler _prevHandler;
        private bool _isRoot;


        public Handler SetRoot()
        {
            _isRoot = true;
            return this;
        }

        public Handler Next(Handler handler)
        {
            _nextHandler = handler;
            _nextHandler._prevHandler = this;
            return _nextHandler;
        }

        public async Task Run(IHandlerData data)
        {
            if(_isRoot)
               await Handle(data);
            else
            {
                _prevHandler?.Run(data);
            }
        }


        protected virtual async Task Handle(IHandlerData data)
        {
            if (_nextHandler != null) await _nextHandler?.Handle(data);
        }
    }
}