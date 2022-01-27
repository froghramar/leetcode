public class Solution {
    public int FindMaximumXOR(int[] nums) {
        Array.Sort(nums);

        var result = 0;
        foreach (var num in nums)
        {
            var mask = 0;
            for (var i = 30; i >= 0; i--)
            {
                if (HasBit(num, i) is false)
                {
                    mask = AlterBit(mask, i);
                    var limit = mask + (1 << i) - 1;
                    if (Find(nums, mask, limit) is false)
                    {
                        mask = AlterBit(mask, i);
                    }
                }
                else
                {
                    var limit = AlterBit(mask, i);
                    if (Find(nums, mask, limit - 1) is false)
                    {
                        mask = AlterBit(mask, i);
                    }
                }
            }
            result = Math.Max(result, num ^ mask);
        }

        return result;
    }

    private bool Find(int[] nums, int min, int max)
    {
        int l = 0, r = nums.Length - 1;
        while (l < r)
        {
            var m = (l + r) / 2;
            if (nums[m] >= min)
            {
                r = m;
            }
            else
            {
                l = m + 1;
            }
        }
        return nums[l] >= min && nums[l] <= max;
    }

    private static bool HasBit(int n, int index)
    {
        return (n & (1 << index)) > 0;
    }
    
    private static int AlterBit(int n, int index)
    {
        return HasBit(n, index) ? RemoveBit(n, index) : SetBit(n, index);
    }

    private static int SetBit(int n, int index)
    {
        return n + (1 << index);
    }
    
    private static int RemoveBit(int n, int index)
    {
        return n - (1 << index);
    }
}