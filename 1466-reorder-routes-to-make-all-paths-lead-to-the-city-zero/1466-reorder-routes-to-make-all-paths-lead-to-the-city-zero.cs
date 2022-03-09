public class Solution {
    public int MinReorder(int n, int[][] connections)
    {
        var adj = new List<Tuple<int, bool>>[n];
        for (var i = 0; i < n; i++)
        {
            adj[i] = new List<Tuple<int, bool>>();
        }

        foreach (var connection in connections)
        {
            adj[connection[0]].Add(new Tuple<int, bool>(connection[1], true));
            adj[connection[1]].Add(new Tuple<int, bool>(connection[0], false));
        }

        var visited = new bool[n];
        visited[0] = true;
        return MinReorderInternal(0, adj, visited);
    }

    private int MinReorderInternal(int i, List<Tuple<int, bool>>[] adj, bool[] visited)
    {
        var result = 0;
        foreach (var (j, opposite) in adj[i])
        {
            if (visited[j])
            {
                continue;
            }

            visited[j] = true;
            if (opposite)
            {
                result++;
            }

            result += MinReorderInternal(j, adj, visited);
        }

        return result;
    }
}