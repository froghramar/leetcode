using System.Threading;

public class FooBar {
    private int n;
    private CountdownEvent[] _fooEvents;
    private CountdownEvent[] _barEvents;

    public FooBar(int n) {
        this.n = n;

        _fooEvents = new CountdownEvent[n];
        _barEvents = new CountdownEvent[n];
        
        for (var i = 0; i < n; i++)
        {
            _fooEvents[i] = new CountdownEvent(1);
            _barEvents[i] = new CountdownEvent(1);
        }
    }

    public void Foo(Action printFoo) {
        
        for (int i = 0; i < n; i++) {

            if (i != 0)
            {
                _barEvents[i - 1].Wait();
            }
            printFoo();
            _fooEvents[i].Signal();
        }
    }

    public void Bar(Action printBar) {
        
        for (int i = 0; i < n; i++)
        {

            _fooEvents[i].Wait();
            printBar();
            _barEvents[i].Signal();
        }
    }
}