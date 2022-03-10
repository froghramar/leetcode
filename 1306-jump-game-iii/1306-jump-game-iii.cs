public class Solution {
    public bool CanReach(int[] arr, int start)
    {
        var n = arr.Length;
        var visited = new bool[n];

        var queue = new Queue<int>();
        Visit(start);
        
        while (queue.Any())
        {
            var p = queue.Dequeue();
            if (arr[p] == 0)
            {
                return true;
            }
            
            Visit(p + arr[p]);
            Visit(p - arr[p]);
        }

        void Visit(int p)
        {
            if (p < 0 || p >= arr.Length || visited[p])
            {
                return;
            }
            
            queue.Enqueue(p);
            visited[p] = true;
        }

        return false;
    }
}