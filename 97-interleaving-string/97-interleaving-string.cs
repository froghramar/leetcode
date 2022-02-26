public class Solution {
    public bool IsInterleave(string s1, string s2, string s3)
    {
        if (s1.Length + s2.Length != s3.Length)
        {
            return false;
        }
        var dp = new int[s1.Length + 1, s2.Length + 1, 2];
        return IsInterleaveInternal(0, 0, 1, s1, s2, s3, dp) || IsInterleaveInternal(0, 0, 0, s1, s2, s3, dp);
    }

    private bool IsInterleaveInternal(int i, int j, int last, string s1, string s2, string s3, int[,,] dp)
    {
        if (i == s1.Length && j == s2.Length)
        {
            return true;
        }

        if (i == s1.Length)
        {
            if (last == 1)
            {
                return false;
            }

            var r = s2.Substring(j) == s3.Substring(i + j);
            dp[i, j, last] = r ? 1 : 2;
            return r;
        }

        if (j == s2.Length)
        {
            if (last == 0)
            {
                return false;
            }

            var r = s1.Substring(i) == s3.Substring(i + j);
            dp[i, j, last] = r ? 1 : 2;
            return r;
        }

        if (dp[i, j, last] != 0)
        {
            return dp[i, j, last] == 1;
        }

        var result = 2;
        if (last == 1)
        {
            for (var k = i; k < s1.Length; k++)
            {
                if (s1[k] != s3[k + j])
                {
                    break;
                }

                if (IsInterleaveInternal(k + 1, j, 0, s1, s2, s3, dp))
                {
                    result = 1;
                    break;
                }
            }
        }
        else
        {
            for (var k = j; k < s2.Length; k++)
            {
                if (s2[k] != s3[i + k])
                {
                    break;
                }

                if (IsInterleaveInternal(i, k + 1, 1, s1, s2, s3, dp))
                {
                    result = 1;
                    break;
                }
            }
        }
        
        dp[i, j, last] = result;
        return result == 1;
    }
}