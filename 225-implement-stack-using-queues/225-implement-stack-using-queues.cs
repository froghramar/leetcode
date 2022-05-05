public class MyStack
{
    private Queue<int> _primary = new();
    private Queue<int> _auxiliary = new();

    public MyStack() { }
    
    public void Push(int x) {
        MoveAll(_primary, _auxiliary);
        _primary.Enqueue(x);
        MoveAll(_auxiliary, _primary);
    }

    public int Pop() {
        return _primary.Dequeue();
    }
    
    public int Top()
    {
        return _primary.Peek();
    }
    
    public bool Empty()
    {
        return _primary.Count == 0;
    }

    private static void MoveAll(Queue<int> from, Queue<int> to)
    {
        while (from.Count > 0)
        {
            var top = from.Dequeue();
            to.Enqueue(top);
        }
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */