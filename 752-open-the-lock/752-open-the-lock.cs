using System.Text;

public class Solution
{
    public int OpenLock(string[] deadends, string target)
    {
        var start = "0000";
        var visited = new HashSet<string>();
        foreach (var deadend in deadends)
        {
            visited.Add(deadend);
        }

        if (visited.Contains(start))
        {
            return -1;
        }

        var queue = new Queue<Tuple<string, int>>();
        queue.Enqueue(new Tuple<string, int>(start, 0));
        visited.Add(start);
        
        while (queue.Any())
        {
            var (curWord, d) = queue.Dequeue();

            if (curWord == target)
            {
                return d;
            }

            for (var i = 0; i < 4; i++)
            {
                Visit(curWord, i, 1, d + 1);
                Visit(curWord, i, -1, d + 1);
            }
        }
        
        void Visit(string curWord, int i, int direction, int d)
        {
            var sb = new StringBuilder(curWord);
            sb[i] = (char) ('0' + (sb[i] - '0' + direction + 10) % 10);

            var next = sb.ToString();

            if (visited.Contains(next) is false)
            {
                queue.Enqueue(new Tuple<string, int>(next, d));
                visited.Add(next);
            }
        }
        
        return -1;
    }
}