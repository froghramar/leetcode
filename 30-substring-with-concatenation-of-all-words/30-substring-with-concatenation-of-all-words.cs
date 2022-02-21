public class Solution {
    public IList<int> FindSubstring(string s, string[] words)
    {
        var trie = new TrieNode();
        var p = 0;
        var wordMap = new Dictionary<string, int>();

        foreach (var word in words)
        {
            if (wordMap.ContainsKey(word) is false)
            {
                wordMap.Add(word, p++);
            }
        }

        var uniqueWordsCount = wordMap.Keys.Count;
        
        foreach (var (word, index) in wordMap)
        {
            trie.Insert(word, index);
        }

        var expectedWordCount = new int[uniqueWordsCount];
        foreach (var word in words)
        {
            expectedWordCount[wordMap[word]]++;
        }

        var result = new List<int>();
        var wordLength = words[0].Length;

        for (var epic = 0; epic < wordLength; epic++)
        {
            int ahead = 0, badCount = 0, behind = uniqueWordsCount, start = epic;
            var wordCount = new int[uniqueWordsCount];
            
            for (var i = epic; i < s.Length - wordLength + 1;)
            {
                var word = s.Substring(i, wordLength);
                var nextIndex = i + wordLength;

                var wordIndex = trie.Find(word);
                if (wordIndex != -1)
                {
                    wordCount[wordIndex]++;

                    if (wordCount[wordIndex] == expectedWordCount[wordIndex])
                    {
                        behind--;
                    }

                    if (wordCount[wordIndex] == expectedWordCount[wordIndex] + 1)
                    {
                        ahead++;
                    }
                }
                else
                {
                    badCount++;
                }

                while (ahead > 0 || badCount > 0)
                {
                    word = s.Substring(start, wordLength);
                    wordIndex = trie.Find(word);

                    if (wordIndex != -1)
                    {
                        wordCount[wordIndex]--;

                        if (wordCount[wordIndex] == expectedWordCount[wordIndex])
                        {
                            ahead--;
                        }

                        if (wordCount[wordIndex] == expectedWordCount[wordIndex] - 1)
                        {
                            behind++;
                        }
                    }
                    else
                    {
                        badCount--;
                    }

                    start += wordLength;
                }
                
                if (ahead == 0 && behind == 0 && badCount == 0)
                {
                    result.Add(start);
                }

                i = nextIndex;
            }
        }
        
        return result;
    }
}

public class TrieNode
{
    private TrieNode[] _links;
    private int _index;

    public TrieNode()
    {
        _index = -1;
        _links = new TrieNode[26];
    }

    public void Insert(string s, int index, int i = 0)
    {
        if (i == s.Length)
        {
            _index = index;
            return;
        }

        var next = s[i] - 'a';
        _links[next] ??= new TrieNode();

        _links[next].Insert(s, index, i + 1);
    }

    public int Find(string s, int i = 0)
    {
        if (i == s.Length)
        {
            return _index;
        }

        var next = s[i] - 'a';
        if (_links[next] == null)
        {
            return -1;
        }

        return _links[next].Find(s, i + 1);
    }
}