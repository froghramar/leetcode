public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        var distance = new int[n];
        var adjacent = new List<Tuple<int, int>>[n];
        for (var i = 0; i < n; i++)
        {
            distance[i] = int.MaxValue;
            adjacent[i] = new List<Tuple<int, int>>();
        }
        
        foreach (var time in times)
        {
            adjacent[time[0] - 1].Add(new Tuple<int, int>(time[1] - 1, time[2]));
        }

        var queue = new PriorityQueue<int, int>();
        queue.Enqueue(k - 1, 0);
        
        distance[k - 1] = 0;
        
        var visited = new bool[n];

        while (queue.Count != 0)
        {
            var current = queue.Dequeue();
            if (visited[current])
            {
                continue;
            }

            visited[current] = true;
            
            foreach (var (next, weight) in adjacent[current])
            {
                var newDistance = distance[current] + weight;
                if (newDistance < distance[next])
                {
                    distance[next] = newDistance;
                    queue.Enqueue(next, newDistance);
                }
            }
        }

        var result = distance.Max();
        return result == int.MaxValue ? - 1: result;
    }
}