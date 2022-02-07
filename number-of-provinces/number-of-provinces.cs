public class Solution {
    public int FindCircleNum(int[][] isConnected)
    {
        var n = isConnected.Length;
        var unionFind = new UnionFind(n);

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                if (isConnected[i][j] == 1)
                {
                    unionFind.Union(i, j);
                }
            }
        }

        return unionFind.GetDistinctRoots();
    }
}

public class UnionFind
{
    private int[] _parents;
    private int[] _ranks;
    
    public UnionFind(int n)
    {
        _parents = new int[n];
        _ranks = new int[n];

        for (var i = 0; i < n; i++)
        {
            _parents[i] = i;
            _ranks[i] = 1;
        }
    }

    public int Find(int x)
    {
        if (x == _parents[x])
        {
            return x;
        }

        return _parents[x] = Find(_parents[x]);
    }

    public void Union(int x, int y)
    {
        var rootX = Find(x);
        var rootY = Find(y);

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
            _parents[rootY] = rootX;
            _ranks[rootX]++;
        }
    }

    public int GetDistinctRoots()
    {
        var roots = new int[_parents.Length];
        for (var i = 0; i < _parents.Length; i++)
        {
            roots[i] = Find(i);
        }
        return roots.Distinct().Count();
    }
}