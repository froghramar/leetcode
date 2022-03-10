public class Solution
{
    public int MinMutation(string start, string end, string[] bank)
    {
        var wordMap = new Dictionary<string, int>();
        for (var i = 0; i < bank.Length; i++)
        {
            wordMap[bank[i]] = i;
        }

        if (wordMap.ContainsKey(end) is false)
        {
            return -1;
        }

        var queue = new Queue<Tuple<int, int>>();
        queue.Enqueue(new Tuple<int, int>(bank.Length, 0));

        var visited = new bool[bank.Length + 1];
        var validChars = new[] { 'A', 'C', 'T', 'G' };

        while (queue.Any())
        {
            var cur = queue.Dequeue();

            if (visited[cur.Item1])
            {
                continue;
            }

            visited[cur.Item1] = true;

            var curWord = cur.Item1 == bank.Length ? start : bank[cur.Item1];

            if (curWord == end) return cur.Item2;

            for (var i = 0; i < curWord.Length; i++)
            {
                var sb = new StringBuilder(curWord);

                for (var j = 0; j < 4; j++)
                {
                    sb[i] = validChars[j];

                    var next = sb.ToString();

                    if (wordMap.ContainsKey(next))
                    {
                        queue.Enqueue(new Tuple<int, int>(wordMap[next], cur.Item2 + 1));
                    }
                }
            }
        }
        
        return -1;
    }
}