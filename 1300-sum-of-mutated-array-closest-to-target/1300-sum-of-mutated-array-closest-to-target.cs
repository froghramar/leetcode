public class Solution {
    public int FindBestValue(int[] arr, int target) {
        Array.Sort(arr);
        
        var prefixSum = new int[arr.Length];
        prefixSum[0] = arr[0];
        for (var i = 1; i < arr.Length; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + arr[i];
        }
        
        int maxNum = arr.Max(), minValue = maxNum, minDiff = Math.Abs(target - prefixSum[^1]);
        for (var value = 0; value < maxNum; value++)
        {
            int l = 0, r = arr.Length - 1;
            if (value < arr[0])
            {
                l = -1;
                r = -1;
            }
            
            while (l < r)
            {
                var m = (l + r + 1) / 2;

                if (value >= arr[m])
                {
                    l = m;
                }
                else
                {
                    r = m - 1;
                }
            }
            
            var sum = l == -1 ? arr.Length * value : (arr.Length - l - 1) * value + prefixSum[l];
            var diff = Math.Abs(target - sum);
            if (diff < minDiff || (diff == minDiff && value < minValue))
            {
                minDiff = diff;
                minValue = value;
            }
        }

        return minValue;
    }
}