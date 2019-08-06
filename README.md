# Easy pipeline in c#
If you want to create a pipeline looks like MiddleWares in the Dotnet core you should use the chain of responsibility design pattern. To ease the implementation I have created a [Nuget](https://www.nuget.org/packages/EasyPipeLine) library in order to easily create a pipeline for your application by using the chain of responsibility and builder patterns together.

Let's say we are going to handle the logic of a coffee shop, the steps are 
* Taking the customer's order 
* receiving the payment 
* making the coffee 

Therefore you can write something simple like this 

```c#

var order = new OrderData()
{
    Name = "Coffee",
    State = "None"
};

await new ExceptionHandler()
    .SetRoot()
    .Next(new OrderHandler())
    .Next(new CheckoutHandler())
    .Next(new ProducingHandler())
    .Run(order);
```

In above scenario the order object will travel through all the handlers starting from the ExceptionHandler and then OrderHandler and so on.

The order object must implement the IHandlerData interface 
```c#
public class OrderData : IHandlerData
{
    public string Name { get; set; }
    public string State { get; set; }
}
```
and every handler must inherit from Handler abstract class
```c#
public class OrderHandler :Handler
{
    protected override async Task Handle(IHandlerData data)
    {
        if(!(data is OrderData order)) throw new ArgumentNullException();
        
        order.State = nameof(OrderHandler);
        
        Console.WriteLine($"State:{nameof(OrderHandler)} objectState: " +
                          $"{JsonConvert.SerializeObject(order)}");
        await base.Handle(order);
    }
}
```

and the logic behind the handler abstract class is 
```c#
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
```

Find the nuget [here](https://www.nuget.org/packages/EasyPipeLine)
