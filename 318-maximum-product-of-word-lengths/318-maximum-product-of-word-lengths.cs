public class Solution {
    public int MaxProduct(string[] words)
    {
        var masks = new int[words.Length];
        for (var i = 0; i < words.Length; i++)
        {
            foreach (var ch in words[i])
            {
                masks[i] |= (1 << (ch - 'a'));
            }
        }

        var max = 0;
        for (var i = 0; i < words.Length; i++)
        {
            for (var j = i + 1; j < words.Length; j++)
            {
                if ((masks[i] & masks[j]) == 0)
                {
                    max = Math.Max(max, words[i].Length * words[j].Length);
                }
            }
        }
        
        return max;
    }
}