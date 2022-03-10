public class Solution
{
    public int MinimumJumps(int[] forbidden, int a, int b, int x)
    {
        var visited = new HashSet<int>();
        foreach (var val in forbidden)
        {
            visited.Add(val);
        }

        var queue = new LinkedList<Tuple<int, bool, int>>();
        queue.AddLast(new Tuple<int, bool, int>(0, false, 0));
        visited.Add(0);
        while (queue.Any())
        {
            var (curPos, backward, steps) = queue.First();
            queue.RemoveFirst();
            if (curPos == x)
            {
                return steps;
            }

            var backwardPos = curPos - b;
            var forwardPos = curPos + a;
            if (backwardPos > 0 && visited.Contains(backwardPos) is false && backward is false)
            {
                queue.AddLast(new Tuple<int, bool, int>(backwardPos, true, steps + 1));
                visited.Add(backwardPos);
            }

            if (forwardPos <= 8000 && visited.Contains(forwardPos) is false)
            {
                queue.AddLast(new Tuple<int, bool, int>(forwardPos, false, steps + 1));
                visited.Add(forwardPos);
            }
        }

        return -1;
    }
}