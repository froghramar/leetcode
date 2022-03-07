public class Solution {
    public string LongestCommonPrefix(string[] strs)
    {
        for (var i = 0; i < strs[0].Length; i++)
        {
            var match = true;
            for (var j = 1; j < strs.Length; j++)
            {
                if (strs[j].Length <= i || strs[j][i] != strs[0][i])
                {
                    match = false;
                    break;
                }
            }

            if (!match)
            {
                return strs[0].Substring(0, i);
            }
        }

        return strs[0];
    }
}