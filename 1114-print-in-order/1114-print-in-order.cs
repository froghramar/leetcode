using System.Threading;

public class Foo
{
    private CountdownEvent _event1 = new CountdownEvent(1);
    private CountdownEvent _event2 = new CountdownEvent(1);

    public Foo() {
    }

    public void First(Action printFirst) {
        printFirst();
        _event1.Signal();
    }

    public void Second(Action printSecond)
    {
        _event1.Wait();
        printSecond();
        _event2.Signal();
    }

    public void Third(Action printThird)
    {
        _event1.Wait();
        _event2.Wait();
        printThird();
    }
}
