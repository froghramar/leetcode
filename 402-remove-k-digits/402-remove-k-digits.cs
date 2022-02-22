using System.Text;

public class Solution
{
    public string RemoveKdigits(string num, int k)
    {
        var occur = new List<int>[10];
        var pos = new int[10];

        for (var i = 0; i < 10; i++) occur[i] = new List<int>();

        for (var i = 0; i < num.Length; i++)
        {
            occur[num[i] - '0'].Add(i);
        }

        var cur = -1;
        var sb = new StringBuilder();

        var remaining = num.Length - k;
        while (remaining > 0)
        {
            for (var i = 0; i < 10; i++)
            {
                while (pos[i] < occur[i].Count && occur[i][pos[i]] <= cur)
                {
                    pos[i]++;
                }
            }

            var take = 0;
            while (take < 10)
            {
                if (pos[take] < occur[take].Count && remaining <= num.Length - occur[take][pos[take]])
                {
                    break;
                }
                take++;
            }

            sb.Append((char) ('0' + take));
            cur = occur[take][pos[take]];
            pos[take]++;
            remaining--;
        }

        var res = sb.ToString().TrimStart(new[] {'0'});

        if (res.Length == 0)
        {
            return "0";
        }

        return res;
    }
}