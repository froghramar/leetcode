public class SnapshotArray
{
    private int[] _current;
    private List<int> _changes = new ();
    private List<KeyValuePair<int, int>>[] _snaps;
    private int _currentSnapId;
    
    public SnapshotArray(int length)
    {
        _current = new int[length];

        _snaps = new List<KeyValuePair<int, int>>[length];
        for (var i = 0; i < length; i++)
        {
            _snaps[i] = new List<KeyValuePair<int, int>>();
        }
    }
    
    public void Set(int index, int val)
    {
        _current[index] = val;
        _changes.Add(index);
    }
    
    public int Snap()
    {
        foreach (var index in _changes)
        {
            _snaps[index].Add(new KeyValuePair<int, int>(_currentSnapId, _current[index]));
        }
        
        _changes.Clear();

        return _currentSnapId++;
    }
    
    public int Get(int index, int snap_id)
    {
        var list = _snaps[index];
        if (list.Count == 0 || snap_id < list[0].Key)
        {
            return 0;
        }

        int l = 0, r = list.Count - 1;
        while (l < r)
        {
            var m = (l + r + 1) / 2;
            if (snap_id >= list[m].Key)
            {
                l = m;
            }
            else
            {
                r = m - 1;
            }
        }
        
        return list[l].Value;
    }
}

/**
 * Your SnapshotArray object will be instantiated and called as such:
 * SnapshotArray obj = new SnapshotArray(length);
 * obj.Set(index,val);
 * int param_2 = obj.Snap();
 * int param_3 = obj.Get(index,snap_id);
 */