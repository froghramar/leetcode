public class Solution {
    public IList<int> EventualSafeNodes(int[][] graph)
    {
        var n = graph.Length;
        var incoming = new List<int>[n];
        for (var i = 0; i < n; i++)
        {
            incoming[i] = new List<int>();
        }

        var outDegree = new int[n];
        for (var i = 0; i < n; i++)
        {
            foreach (var j in graph[i])
            {
                incoming[j].Add(i);
                outDegree[i]++;
            }
        }

        var result = new List<int>();
        var queue = new Queue<int>();
        for (var i = 0; i < n; i++)
        {
            if (outDegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }

        while (queue.Any())
        {
            var i = queue.Dequeue();
            result.Add(i);

            foreach (var j in incoming[i])
            {
                outDegree[j]--;

                if (outDegree[j] == 0)
                {
                    queue.Enqueue(j);
                }
            }
        }
        
        result.Sort();
        
        return result;
    }
}