public class MyCalendar
{
    private List<Tuple<int, int>> _events = new();

    public MyCalendar() {
    }
    
    public bool Book(int start, int end)
    {
        if (_events.Any(sv => Math.Min(sv.Item2, end) - Math.Max(sv.Item1, start) > 0))
        {
            return false;
        }
        
        _events.Add(new Tuple<int, int>(start, end));
        return true;
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */