public class Solution {
    public int MinimumDeviation(int[] nums)
    {
        var queue = new PriorityQueue<int, int>();

        var min = int.MaxValue;
        foreach (var num in nums)
        {
            var cur = num;
            if (cur % 2 == 1)
            {
                cur *= 2;
            }

            min = Math.Min(min, cur);
            queue.Enqueue(cur, -cur);
        }

        var diff = int.MaxValue;
        while (queue.Peek() % 2 == 0)
        {
            var max = queue.Dequeue();
            diff = Math.Min(diff, max - min);

            var newVal = max / 2;
            min = Math.Min(newVal, min);
            queue.Enqueue(newVal, -newVal);
        }

        return Math.Min(diff, queue.Peek() - min);
    }
}