public class Solution {
    public string MinWindow(string s, string t)
    {
        var expected = new int[52];
        foreach (var ch in t)
        {
            expected[Hash(ch)]++;
        }

        var count = new int[52];
        int behind = expected.Count(e => e > 0), start = 0, end = -1;

        int ri = -1, rj = -1;
        while (start < s.Length)
        {
            var hash = -1;
            while (behind > 0 && end < s.Length - 1)
            {
                end++;
                
                hash = Hash(s[end]);
                count[hash]++;

                if (count[hash] == expected[hash])
                {
                    behind--;
                }
            }

            if (behind == 0 && (ri == - 1 || end - start < rj - ri))
            {
                ri = start;
                rj = end;
            }

            hash = Hash(s[start]);
            count[hash]--;

            if (count[hash] == expected[hash] - 1)
            {
                behind++;
            }

            start++;
        }

        return ri == - 1 ? string.Empty : s.Substring(ri, rj - ri + 1);
    }

    private static int Hash(char ch)
    {
        if (char.IsUpper(ch))
        {
            return ch - 'A';
        }

        return ch - 'a' + 26;
    }
}