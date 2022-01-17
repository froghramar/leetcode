using System.Text;

public class Solution {
    public string CountAndSay(int n) {
        if (n == 1)
        {
            return "1";
        }

        var prev = CountAndSay(n - 1);
        var result = new StringBuilder();

        var currentChar = 'x';
        var currentCount = 0;

        foreach (var ch in prev)
        {
            if (ch == currentChar)
            {
                currentCount++;
            }
            else
            {
                if (currentCount > 0)
                {
                    result.Append(currentCount);
                    result.Append(currentChar);
                }
                currentChar = ch;
                currentCount = 1;
            }
        }
        
        if (currentCount > 0)
        {
            result.Append(currentCount);
            result.Append(currentChar);
        }

        return result.ToString();
    }
}