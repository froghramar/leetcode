public class MyCircularQueue
{
    private int _limit, _size, _start, _end;
    private int[] _arr;

    public MyCircularQueue(int k)
    {
        _limit = k;
        _start = 0;
        _end = -1;
        _size = 0;

        _arr = new int[k];
    }
    
    public bool EnQueue(int value) {
        if (IsFull())
        {
            return false;
        }

        _end = (_end + 1) % _limit;
        _arr[_end] = value;
        _size++;

        return true;
    }
    
    public bool DeQueue() {
        if (IsEmpty())
        {
            return false;
        }

        _start = (_start + 1) % _limit;
        _size--;

        return true;
    }
    
    public int Front()
    {
        return IsEmpty() ? -1 : _arr[_start];
    }
    
    public int Rear() {
        return IsEmpty() ? -1 : _arr[_end];
    }
    
    public bool IsEmpty() {
        return _size == 0;
    }
    
    public bool IsFull()
    {
        return _size == _limit;
    }
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */