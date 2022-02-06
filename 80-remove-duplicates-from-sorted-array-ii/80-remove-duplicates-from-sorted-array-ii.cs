public class Solution {
    public int RemoveDuplicates(int[] nums)
    {
        int k = 0, previous = int.MaxValue, previousLast = int.MaxValue;
        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            if (num == previous && num == previousLast)
            {
                nums[i] = int.MaxValue;
                continue;
            }

            previousLast = previous;
            previous = num;

            nums[k++] = num;
        }

        return k;
    }
}