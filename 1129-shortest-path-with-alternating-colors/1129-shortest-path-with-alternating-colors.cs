public class Solution {
    public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
    {
        var shortest = new int[n, 2];
        var edges = new List<int>[n, 2];
        for (var i = 0; i < n; i++)
        {
            shortest[i, 0] = shortest[i, 1] = int.MaxValue;
            edges[i, 0] = new List<int>();
            edges[i, 1] = new List<int>();
        }

        foreach (var edge in redEdges)
        {
            edges[edge[0], 0].Add(edge[1]);
        }
        
        foreach (var edge in blueEdges)
        {
            edges[edge[0], 1].Add(edge[1]);
        }

        var queue = new Queue<Tuple<int, int>>();
        queue.Enqueue(new Tuple<int, int>(0, 0));
        shortest[0, 0] = 0;
        
        queue.Enqueue(new Tuple<int, int>(0, 1));
        shortest[0, 1] = 0;

        while (queue.Any())
        {
            var (i, currentColor) = queue.Dequeue();

            var nextColor = 1 - currentColor;
            foreach (var j in edges[i, nextColor])
            {
                var nextD = 1 + shortest[i, currentColor];
                if (nextD < shortest[j, nextColor])
                {
                    queue.Enqueue(new Tuple<int, int>(j, nextColor));
                    shortest[j, nextColor] = nextD;
                }
            }
        }

        var res = new int[n];
        for (var i = 0; i < n; i++)
        {
            res[i] = Math.Min(shortest[i, 0], shortest[i, 1]);
            if (res[i] == int.MaxValue)
            {
                res[i] = -1;
            }
        }

        return res;
    }
}