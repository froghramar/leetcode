public class TimeMap
{
    private Dictionary<string, List<KeyValuePair<int, string>>> _map =  new ();

    public TimeMap() { }
    
    public void Set(string key, string value, int timestamp)
    {
        var entry = new KeyValuePair<int, string>(timestamp, value);
        if (_map.ContainsKey(key) is false)
        {
            _map[key] = new List<KeyValuePair<int, string>> { entry,};
        }
        else
        {
            _map[key].Add(entry);
        }
    }
    
    public string Get(string key, int timestamp)
    {
        if (_map.ContainsKey(key) is false)
        {
            return string.Empty;
        }

        var list = _map[key];
        if (timestamp < list[0].Key)
        {
            return string.Empty;
        }
        
        int l = 0, r = list.Count - 1;
        while (l < r)
        {
            var m = (l + r + 1) / 2;
            if (timestamp >= list[m].Key)
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
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */