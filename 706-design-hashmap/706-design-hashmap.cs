public class MyHashMap
{
    private int[] _values;
    
    public MyHashMap()
    {
        _values = new int[1000005];

        for (var i = 0; i < _values.Length; i++)
        {
            _values[i] = -1;
        }
    }
    
    public void Put(int key, int value)
    {
        _values[key] = value;
    }
    
    public int Get(int key)
    {
        return _values[key];
    }
    
    public void Remove(int key)
    {
        _values[key] = -1;
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */