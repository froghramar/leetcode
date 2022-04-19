public class Solution {
    public int TriangleNumber(int[] nums)
    {
        Array.Sort(nums);
        int[] count = new int[2001], cum = new int[2001];
        foreach (var num in nums)
        {
            count[num]++;
        }

        for (var i = 1; i <= 2000; i++)
        {
            cum[i] = cum[i - 1] + count[i];
        }

        var res = 0;
        for (var i = 1; i <= 1000; i++)
        {
            if (count[i] == 0)
            {
                continue;
            }
            
            // case - {i, i, i}
            int toAdd;
            if (count[i] > 2)
            {
                toAdd = (count[i] * (count[i] - 1) * (count[i] - 2)) / 6;
                res += toAdd;
            }
            
            int minK, maxK;
            if (count[i] > 1)
            {
                var takeI = (count[i] * (count[i] - 1)) / 2;
                
                // case - {i, i, k}
                minK = i + 1;
                maxK = i + i - 1;
                toAdd = takeI * (cum[maxK] - cum[minK - 1]);
                res += toAdd;
                
                // case - {k, i, i}
                toAdd = takeI * cum[i - 1];
                res += toAdd;
            }

            // case - {i, j, k}
            for (var j = i + 1; j < 1000; j++)
            {
                minK = j + 1;
                maxK = i + j - 1;
                toAdd = count[i] * count[j] * (cum[maxK] - cum[minK - 1]);
                res += toAdd;
            }
        }

        return res;
    }
}