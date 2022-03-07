public class Solution {
    public bool IsAlienSorted(string[] words, string order)
    {
        var index = new int[27];
        for (var i = 0; i < 26; i++)
        {
            index[order[i] - 'a' + 1] = i + 1;
        }

        for (var i = 1; i < words.Length; i++)
        {
            if (Compare(words[i - 1], words[i], index) == 1)
            {
                return false;
            }
        }

        return true;
    }

    private static int Compare(string s1, string s2, int[] index)
    {
        for (var i = 0; i < s1.Length || i < s2.Length; i++)
        {
            var firstChar = GetCharIndex(s1, i);
            var secondChar = GetCharIndex(s2, i);

            if (index[firstChar] < index[secondChar])
            {
                return -1;
            }

            if (index[firstChar] > index[secondChar])
            {
                return 1;
            }
        }

        return 0;
    }
    
    private static int GetCharIndex(string word, int i)
    {
        if (i >= word.Length)
        {
            return 0;
        }

        return word[i] - 'a' + 1;
    }
}