public class Solution
{
    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
    {
        var graph = new List<int>[n];
        for (var i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
        }

        var connectionsSet = new HashSet<KeyValuePair<int, int>>();
        foreach (var connection in connections)
        {
            var x = connection[0];
            var y = connection[1];

            graph[x].Add(y);
            graph[y].Add(x);

            connectionsSet.Add(new KeyValuePair<int, int>(Math.Min(x, y), Math.Max(x, y)));
        }

        var rank = new int[n];
        Array.Fill(rank, -2);
        DFS(graph, 0, 0, rank, connectionsSet);
        var result = new List<IList<int>>();
        foreach (var pair in connectionsSet)
        {
            result.Add(new List<int> {pair.Key, pair.Value});
        }

        return result;
    }

    private int DFS(List<int>[] graph, int node, int depth, int[] rank, HashSet<KeyValuePair<int, int>> connectionsSet)
    {
        if (rank[node] >= 0)
        {
            return rank[node];
        }

        rank[node] = depth;
        var minDepthFound = depth;
        foreach (var neighbor in graph[node])
        {
            if (rank[neighbor] == depth - 1)
            {
                continue;
            }

            var minDepth = DFS(graph, neighbor, depth + 1, rank, connectionsSet);
            minDepthFound = Math.Min(minDepthFound, minDepth);
            if (minDepth <= depth)
            {
                connectionsSet.Remove(new KeyValuePair<int, int>(Math.Min(node, neighbor), Math.Max(node, neighbor)));
            }
        }

        return minDepthFound;
    }
}