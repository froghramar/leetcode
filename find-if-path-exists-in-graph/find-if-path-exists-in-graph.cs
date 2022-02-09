public class Solution {
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        var links = new List<int>[n];
        for (var i = 0; i < n; i++)
        {
            links[i] = new List<int>();
        }

        foreach (var edge in edges)
        {
            links[edge[0]].Add(edge[1]);
            links[edge[1]].Add(edge[0]);
        }

        var visited = new bool[n];
        return Traverse(links, source, destination, visited);
    }

    private bool Traverse(List<int>[] links, int current, int destination, bool[] visited)
    {
        if (current == destination)
        {
            return true;
        }

        if (visited[current])
        {
            return false;
        }

        visited[current] = true;
        foreach (var next in links[current])
        {
            if (Traverse(links, next, destination, visited))
            {
                return true;
            }
        }
        
        return false;
    }
}