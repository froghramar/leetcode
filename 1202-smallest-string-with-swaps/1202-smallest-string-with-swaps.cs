using System.Text;

public class Solution
{
    private int[] _parents;
    private int[] _ranks;
    
    public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
    {
        var sb = new StringBuilder(s);
        _parents = new int[s.Length];
        _ranks = new int[s.Length];
        var setIndexes = new List<int>[s.Length];
        var setChars = new List<char>[s.Length];

        for (var i = 0; i < s.Length; i++)
        {
            _parents[i] = i;
            _ranks[i] = 1;
            setIndexes[i] = new List<int>();
            setChars[i] = new List<char>();
        }
        
        foreach (var pair in pairs)
        {
            Union(pair[0], pair[1]);
        }
        
        for (var i = 0; i < s.Length; i++)
        {
            var parent = Find(i);
            setIndexes[parent].Add(i);
            setChars[parent].Add(s[i]);
        }

        var sorted = new bool[s.Length];
        for (var i = 0; i < s.Length; i++)
        {
            if (sorted[i])
            {
                continue;
            }
            
            setChars[i].Sort();

            for (var j = 0; j < setChars[i].Count; j++)
            {
                sb[setIndexes[i][j]] = setChars[i][j];
            }

            sorted[i] = true;
        }
        
        return sb.ToString();
    }

    private void Union(int x, int y)
    {
        var rootX = Find(x);
        var rootY = Find(y);

        if (rootX == rootY)
        {
            return;
        }

        if (_ranks[rootX] > _ranks[rootY])
        {
            _parents[rootY] = rootX;
        }
        else if (_ranks[rootX] < _ranks[rootY])
        {
            _parents[rootX] = rootY;
        }
        else
        {
            _parents[rootX] = rootY;
            _ranks[rootY]++;
        }
    }

    private int Find(int x)
    {
        if (x == _parents[x])
        {
            return x;
        }

        return _parents[x] = Find(_parents[x]);
    }
}