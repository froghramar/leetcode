public class Solution {
    public int SumOddLengthSubarrays(int[] arr)
    {
        var res = 0;
        for (var i = 0; i < arr.Length; i++)
        {
            var sum = arr[i];
            res += sum;

            for (var j = i + 2; j < arr.Length; j += 2)
            {
                sum += arr[j] + arr[j - 1];
                res += sum;
            }
        }
        return res;
    }
}