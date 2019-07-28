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

        public void Run(IHandlerData data)
        {
            if(_isRoot)
               Handle(data);
            else
            {
                _prevHandler?.Run(data);
            }
        }


        protected virtual void Handle(IHandlerData data)
        {
            _nextHandler?.Handle(data);
        }
    }
}