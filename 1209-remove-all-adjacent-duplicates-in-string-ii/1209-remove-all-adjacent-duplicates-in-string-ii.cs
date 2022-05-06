public class Solution {
    public string RemoveDuplicates(string s, int k)
    {
        var n = s.Length;
        
        var res = new char[n];
        var count = new int[n];
        var resLen = 0;

        for (var i = 0; i < n; i++)
        {
            if (resLen > 0 && s[i] == res[resLen - 1])
            {
                count[resLen] = count[resLen - 1] + 1;
            }
            else
            {
                count[resLen] = 1;
            }

            if (count[resLen] == k)
            {
                resLen = resLen - k + 1;
            }
            else
            {
                res[resLen] = s[i];
                resLen++;
            }
        }

        return new string(res.Take(resLen).ToArray());
    }
}