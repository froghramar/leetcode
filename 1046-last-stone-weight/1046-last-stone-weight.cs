public class Solution {
    public int LastStoneWeight(int[] stones)
    {
        var queue = new PriorityQueue<int, int>();
        foreach (var stone in stones)
        {
            queue.Enqueue(stone, -stone);
        }

        while (queue.Count >= 2)
        {
            var y = queue.Dequeue();
            var x = queue.Dequeue();

            if (x != y)
            {
                queue.Enqueue(y - x, x - y);
            }
        }
        
        return queue.TryPeek(out var element, out _) ? element : 0;
    }
}