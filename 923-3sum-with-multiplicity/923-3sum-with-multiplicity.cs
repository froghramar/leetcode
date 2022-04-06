public class Solution {
    public int ThreeSumMulti(int[] arr, int target)
    {
        var count = new int[101];
        foreach (var t in arr)
        {
            count[t]++;
        }

        const int MOD = (int)1e9 + 7;
        var result = 0;
        for (var i = 0; i <= 100; i++)
        {
            for (var j = i; j <= 100; j++)
            {
                var k = target - j - i;
                if (k >= j && k <= 100)
                {
                    var t = Consider(i, j, k);
                    result = (result + t) % MOD;
                }
            }
        }

        int Consider(int i, int j, int k)
        {
            if (i == j && j == k)
            {
                return C(count[i], 3);
            }

            if (i == j)
            {
                return M(count[k], C(count[i], 2));
            }
            
            if (j == k)
            {
                return M(count[i], C(count[j], 2));
            }

            return M(count[i], M(count[j], count[k]));
        }

        int C(int n, int r) {

            if (r > n)
            {
                return 0;
            }
            
            if (r > n - r)
            {
                r = n - r;
            }

            long ans = 1;

            for(var i = 1; i <= r; i++)
            {
                ans *= n - r + i;
                ans /= i;
            }

            return (int)(ans % MOD);
        }

        int M(int x, int y)
        {
            return (int)(((long)x * y) % MOD);
        }

        return result;
    }
}