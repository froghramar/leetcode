public class Solution
{
    private int[] _rank;
    private int[] _parent;
    private double[] _division;

    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        var variables = equations.SelectMany(equation => equation).Distinct().ToList();
        variables.Sort();
        
        var n = variables.Count;

        _rank = new int[n];
        _parent = new int[n];
        _division = new double[n];

        for (var i = 0; i < n; i++)
        {
            _parent[i] = i;
            _rank[i] = 1;
            _division[i] = 1.0;
        }

        for (var i = 0; i < equations.Count; i++)
        {
            var equation = equations[i];

            var x = FindIndex(variables, equation[0]);
            var y = FindIndex(variables, equation[1]);
            
            Union(x, y, values[i]);
        }

        var result = new double[queries.Count];

        for (var i = 0; i < queries.Count; i++)
        {
            var query = queries[i];

            var x = FindIndex(variables, query[0]);
            var y = FindIndex(variables, query[1]);

            if (x == -1 || y == -1)
            {
                result[i] = -1;
                continue;
            }

            var (rootX, divisionRootX) = Find(x);
            var (rootY, divisionRootY) = Find(y);

            if (rootX != rootY)
            {
                result[i] = -1;
            }
            else
            {
                result[i] = divisionRootY / divisionRootX;
            }
        }
        
        return result;
    }

    private (int, double) Find(int x)
    {
        if (x == _parent[x])
        {
            return (x, _division[x]);
        }
        
        var (rootX, divisionRootX) = Find(_parent[x]);
        return (_parent[x], _division[x]) = (rootX, divisionRootX * _division[x]);
    }

    private void Union(int x, int y, double val)
    {
        var (rootX, _) = Find(x);
        var (rootY, _) = Find(y);

        if (rootX == rootY)
        {
            return;
        }

        if (_rank[rootX] > _rank[rootY])
        {
            _parent[rootY] = rootX;
            _division[rootY] = _division[x] * val / _division[y];
        }
        else if (_rank[rootX] < _rank[rootY])
        {
            _parent[rootX] = rootY;
            _division[rootX] = _division[y] / (_division[x] * val);
        }
        else
        {
            _parent[rootY] = rootX;
            _division[rootY] = _division[x] * val / _division[y];
            _rank[rootX]++;
        }
    }

    private static int FindIndex(List<string> list, string str)
    {
        return list.FindIndex(element => element == str);
    }
}