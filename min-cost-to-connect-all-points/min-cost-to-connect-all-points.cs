public record Edge(int From, int To, int Weight);

public class Solution
{
    private int[] _parent;
    private int[] _rank;
    
    public int MinCostConnectPoints(int[][] points)
    {
        _parent = new int[points.Length];
        _rank = new int[points.Length];
        
        var edges = new List<Edge>();
        for (var i = 0; i < points.Length; i++)
        {
            _parent[i] = i;
            _rank[i] = 1;
            
            for (var j = i + 1; j < points.Length; j++)
            {
                edges.Add(new Edge(i, j, Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1])));
            }
        }

        edges.Sort((e1, e2) => e1.Weight - e2.Weight);

        var result = 0;
        foreach (var edge in edges)
        {
            if (Union(edge.From, edge.To))
            {
                result += edge.Weight;
            }
        }
        
        return result;
    }

    private int Find(int i)
    {
        if (i == _parent[i])
        {
            return i;
        }

        return _parent[i] = Find(_parent[i]);
    }

    private bool Union(int i, int j)
    {
        var rootI = Find(i);
        var rootJ = Find(j);

        if (rootI == rootJ)
        {
            return false;
        }

        if (_rank[rootI] > _rank[rootJ])
        {
            _parent[rootJ] = rootI;
        }
        else if (_rank[rootI] < _rank[rootJ])
        {
            _parent[rootI] = rootJ;
        }
        else
        {
            _parent[rootJ] = rootI;
            _rank[rootI]++;
        }

        return true;
    }
}