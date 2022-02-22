using System.Text;

public class Solution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        var wordMap = new Dictionary<string, int>();

        for (var i = 0; i < wordList.Count; i++)
        {
            wordMap[wordList[i]] = i;
        }

        if (wordMap.ContainsKey(endWord) is false)
        {
            return 0;
        }

        var queue = new Queue<Tuple<int, int>>();

        queue.Enqueue(new Tuple<int, int>(wordList.Count, 1));

        var visited = new bool[wordList.Count + 1];

        while (queue.Any())
        {
            var cur = queue.Dequeue();

            if (visited[cur.Item1])
            {
                continue;
            }

            visited[cur.Item1] = true;

            var curWord = cur.Item1 == wordList.Count ? beginWord : wordList[cur.Item1];

            if (curWord == endWord) return cur.Item2;

            for (var i = 0; i < curWord.Length; i++)
            {
                var sb = new StringBuilder(curWord);

                for (var j = 0; j < 26; j++)
                {
                    sb[i] = (char) ('a' + j);

                    var next = sb.ToString();

                    if (wordMap.ContainsKey(next))
                    {
                        queue.Enqueue(new Tuple<int, int>(wordMap[next], cur.Item2 + 1));
                    }
                }
            }
        }
        
        return 0;
    }
}