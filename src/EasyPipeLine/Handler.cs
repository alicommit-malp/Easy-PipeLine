using System;
using System.Threading.Tasks;

namespace EasyPipeLine
{
    [Obsolete("Handler class has been deprecated, please drive from Link class instead")]
    public abstract class Handler
    {
        private Handler _nextHandler;
        private Handler _prevHandler;
        private bool _isRoot;


        [Obsolete("SetRoot method has been deprecated, please use Pipeline class instead")]
        public Handler SetRoot()
        {
            _isRoot = true;
            return this;
        }

        [Obsolete("Handler class has been deprecated, please drive from Link class instead")]
        public Handler Next(Handler handler)
        {
            _nextHandler = handler;
            _nextHandler._prevHandler = this;
            return _nextHandler;
        }

        [Obsolete("Handler class has been deprecated, please drive from Link class instead")]
        public async Task Run(IHandlerData data)
        {
            if (_isRoot)
                await Handle(data);
            else
            {
                _prevHandler?.Run(data);
            }
        }


        [Obsolete(
            "Handle method has been deprecated, please drive from Link class and implement the InvokeAsync method instead")]
        protected virtual async Task Handle(IHandlerData data)
        {
            if (_nextHandler != null) await _nextHandler?.Handle(data);
        }
    }
}