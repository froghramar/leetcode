public class FreqStack
{
    private PriorityQueue<int, int> _queue;
    private Dictionary<int, int> _count;
    private int _index;

    private const int DIMENSION = 20005;

    public FreqStack()
    {
        _queue = new PriorityQueue<int, int>();
        _count = new Dictionary<int, int>();
        _index = 0;
    }
    
    public void Push(int val) {
        if (_count.ContainsKey(val))
        {
            _count[val]++;
        }
        else
        {
            _count[val] = 1;
        }

        var priority = _count[val] * DIMENSION + _index++;
        _queue.Enqueue(val, -priority);
    }
    
    public int Pop()
    {
        var val = _queue.Dequeue();
        _count[val]--;
        return val;
    }
}

/**
 * Your FreqStack object will be instantiated and called as such:
 * FreqStack obj = new FreqStack();
 * obj.Push(val);
 * int param_2 = obj.Pop();
 */