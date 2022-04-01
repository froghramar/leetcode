public class SeatManager
{
    private PriorityQueue<int, int> _queue;

    public SeatManager(int n)
    {
        _queue = new PriorityQueue<int, int>();
        for (var i = 1; i <= n; i++)
        {
            _queue.Enqueue(i, i);
        }
    }
    
    public int Reserve()
    {
        return _queue.Dequeue();
    }
    
    public void Unreserve(int seatNumber)
    {
        _queue.Enqueue(seatNumber, seatNumber);
    }
}