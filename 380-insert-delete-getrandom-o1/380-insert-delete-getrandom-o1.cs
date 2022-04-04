public class RandomizedSet {
    private List<int> list = new ();
    private Dictionary<int, int> numToIdx = new ();
    private Random rand = new ();

    public RandomizedSet() {
    }
    
    public bool Insert(int val) {
        if (numToIdx.ContainsKey(val)) {
            return false;
        }
        
        list.Add(val);
        numToIdx[val] = list.Count - 1;
        return true;
    }
    
    public bool Remove(int val) {
        if (!numToIdx.ContainsKey(val)) {
            return false;
        }
        
        var idx = numToIdx[val];
        var lastVal = list[^1];
        
        list[idx] = lastVal;
        list.RemoveAt(list.Count - 1);
        
        numToIdx[lastVal] = idx;
        numToIdx.Remove(val);
        
        return true;
    }
    
    public int GetRandom() {
        var randIdx = rand.Next(list.Count);
        return list[randIdx];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */