public class Solution {
    public IList<string> RestoreIpAddresses(string s)
    {
        var result = new List<string>();
        for (var i = 0; i < s.Length; i++)
        {
            var a = s.Substring(0, i + 1);
            if (IsValid(a) is false)
            {
                continue;
            }
            
            for (var j = i + 1; j < s.Length; j++)
            {
                var b = s.Substring(i + 1, j - i);
                if (IsValid(b) is false)
                {
                    continue;
                }
                
                for (var k = j + 1; k < s.Length; k++)
                {
                    var c = s.Substring(j + 1, k - j);
                    if (IsValid(c) is false)
                    {
                        continue;
                    }
                    
                    var d = s.Substring(k + 1);
                        
                    if (IsValid(d))
                    {
                        result.Add($"{a}.{b}.{c}.{d}");
                    }
                }
            }
        }

        return result;
    }

    private static bool IsValid(string s)
    {
        if (s == "0")
        {
            return true;
        }
        return s.Length is > 0 and < 4 && s[0] != '0' && int.Parse(s) < 256;
    }
}