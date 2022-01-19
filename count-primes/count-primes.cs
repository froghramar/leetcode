public class Solution {
    public int CountPrimes(int n)
    {
        var isPrime = new bool[n];
        for (var p = 2; p < n; p++)
        {
            isPrime[p] = true;
        }

        int count = 0, sqrtN = (int) Math.Sqrt(n);
        for (var p = 2; p < n; p++)
        {
            if (isPrime[p] is false)
            {
                continue;
            }

            count++;

            if (p > sqrtN)
            {
                continue;
            }
            
            for (var i = p * p; i < n; i += p)
            {
                isPrime[i] = false;
            }
        }

        return count;
    }
}