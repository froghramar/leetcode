public class MyQueue
{
    private Stack<int> mainStack, helperStack;
    public MyQueue()
    {
        mainStack = new Stack<int>();
        helperStack = new Stack<int>();
    }
    
    public void Push(int x) {
        while (mainStack.Any())
        {
            var val = mainStack.Pop();
            helperStack.Push(val);
        }
        
        mainStack.Push(x);

        while (helperStack.Any())
        {
            var val = helperStack.Pop();
            mainStack.Push(val);
        }
    }
    
    public int Pop()
    {
        return mainStack.Pop();
    }
    
    public int Peek()
    {
        return mainStack.Peek();
    }
    
    public bool Empty()
    {
        return mainStack.Any() is false;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */