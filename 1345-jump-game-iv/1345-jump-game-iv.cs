class Solution
{
    public int MinJumps(int[] arr)
    {
        var n = arr.Length;
        if (n <= 1) return 0;

        var graph = new Dictionary<int, LinkedList<int>>();
        for (var i = 0; i < n; i++)
        {
            if (!graph.ContainsKey(arr[i])) graph[arr[i]] = new LinkedList<int>();

            graph[arr[i]].AddLast(i);
        }

        var curs = new LinkedList<int>();
        curs.AddLast(0);
        var visited = new HashSet<int>();
        var step = 0;
        
        while (curs.Any())
        {
            var nex = new LinkedList<int>();
            
            foreach (var node in curs)
            {
                if (node == n - 1) return step;
                
                foreach (var child in graph[arr[node]])
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        nex.AddLast(child);
                    }
                
                graph[arr[node]].Clear();
                
                if (node + 1 < n && !visited.Contains(node + 1))
                {
                    visited.Add(node + 1);
                    nex.AddLast(node + 1);
                }

                if (node - 1 >= 0 && !visited.Contains(node - 1))
                {
                    visited.Add(node - 1);
                    nex.AddLast(node - 1);
                }
            }

            curs = nex;
            step++;
        }

        return -1;
    }
}