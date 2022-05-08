public class Solution
{
    private int[] _parent;
    private int[] _count;
    private int[] _rank;
    private int[] _countMap;
    
    public int FindLatestStep(int[] arr, int m)
    {
        _parent = new int[arr.Length];
        _count = new int[arr.Length];
        _rank = new int[arr.Length];
        _countMap = new int[arr.Length + 1];

        for (var i = 0; i < arr.Length; i++)
        {
            _parent[i] = i;
        }

        var result = -1;
        for (var i = 0; i < arr.Length; i++)
        {
            var pos = arr[i];
            var cur = pos - 1;
            _count[cur] = 1;
            _countMap[1]++;

            var prev = pos - 2;
            if (prev >= 0)
            {
                var prevParent = Find(prev);
                if (_count[prevParent] > 0)
                {
                    Union(cur, prev);
                }
            }
            
            var next = pos;
            if (next < arr.Length)
            {
                var nextParent = Find(next);
                if (_count[nextParent] > 0)
                {
                    Union(cur, next);
                }
            }
            
            if (_countMap[m] > 0)
            {
                result = i + 1;
            }
        }

        return result;
    }

    private int Find(int x)
    {
        if (_parent[x] == x)
        {
            return x;
        }

        return _parent[x] = Find(_parent[x]);
    }

    private void Union(int x, int y)
    {
        var rootX = Find(x);
        var rootY = Find(y);

        if (rootX == rootY)
        {
            return;
        }
        
        _countMap[_count[rootX]]--;
        _countMap[_count[rootY]]--;

        if (_rank[rootX] > _rank[rootY])
        {
            _parent[rootY] = rootX;
            _count[rootX] += _count[rootY];
            _countMap[_count[rootX]]++;
        }
        else if (_rank[rootX] < _rank[rootY])
        {
            _parent[rootX] = rootY;
            _count[rootY] += _count[rootX];
            _countMap[_count[rootY]]++;
        }
        else
        {
            _parent[rootY] = rootX;
            _count[rootX] += _count[rootY];
            _countMap[_count[rootX]]++;
            _rank[rootX]++;
        }
    }
}