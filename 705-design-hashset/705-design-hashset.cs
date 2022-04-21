public class MyHashSet
{
    private bool[] _keys;
    public MyHashSet()
    {
        _keys = new bool[1_000_001];
    }
    
    public void Add(int key)
    {
        _keys[key] = true;
    }
    
    public void Remove(int key)
    {
        _keys[key] = false;
    }
    
    public bool Contains(int key)
    {
        return _keys[key];
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */