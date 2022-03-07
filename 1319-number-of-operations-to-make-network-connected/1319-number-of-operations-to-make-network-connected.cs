public class Solution
{
    private int[] _parent;
    private int[] _rank;
    
    public int MakeConnected(int n, int[][] connections)
    {
        if (connections.Length < n - 1)
        {
            return -1;
        }
        
        _parent = new int[n];
        _rank = new int[n];

        for (var i = 0; i < n; i++)
        {
            _parent[i] = i;
            _rank[i] = 1;
        }

        foreach (var connection in connections)
        {
            Union(connection[0], connection[1]);
        }

        return _parent.Select(Find).Distinct().Count() - 1;
    }

    int Find(int x)
    {
        if (x == _parent[x])
        {
            return x;
        }

        return _parent[x] = Find(_parent[x]);
    }

    void Union(int x, int y)
    {
        var rootX = Find(x);
        var rootY = Find(y);

        if (rootX == rootY)
        {
            return;
        }

        if (_rank[rootX] < _rank[rootY])
        {
            _parent[rootX] = rootY;
        }
        else if (_rank[rootX] > _rank[rootY])
        {
            _parent[rootY] = rootX;
        }
        else
        {
            _parent[rootY] = rootX;
            _rank[rootX]++;
        }
    }
}