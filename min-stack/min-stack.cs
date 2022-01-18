public class MinStack
{
    private int[] _stack;
    private int[] _minStack;
    private int r;
    
    public MinStack()
    {
        _stack = new int[30005];
        _minStack = new int[30005];
        r = 0;
    }
    
    public void Push(int val)
    {
        _stack[r] = val;

        if (r == 0)
        {
            _minStack[0] = val;
        }
        else
        {
            _minStack[r] = Math.Min(val, _minStack[r - 1]);
        }
        
        r++;
    }
    
    public void Pop()
    {
        r--;
    }
    
    public int Top()
    {
        return _stack[r - 1];
    }
    
    public int GetMin()
    {
        return _minStack[r - 1];
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */