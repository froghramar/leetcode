public record Edge(int To, int Weight);

public class Solution {
    public int MinCostConnectPoints(int[][] points)
    {
        var queue = new PriorityQueue<Edge, int>();
        queue.Enqueue(new Edge(0, 0), 0);
        
        var remaining = new HashSet<int>();
        for (var i = 0; i < points.Length; i++)
        {
            remaining.Add(i);
        }

        var result = 0;
        while (queue.Count != 0)
        {
            var current = queue.Dequeue();

            if (remaining.Contains(current.To) is false)
            {
                continue;
            }

            remaining.Remove(current.To);
            result += current.Weight;
            
            foreach (var next in remaining)
            {
                var weight = Math.Abs(points[current.To][0] - points[next][0]) + Math.Abs(points[current.To][1] - points[next][1]);
                queue.Enqueue(new Edge(next, weight), weight);
            }
        }

        return result;
    }
}