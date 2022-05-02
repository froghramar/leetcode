public class Solution {
    public int[] SortArrayByParity(int[] nums)
    {
        var result = new int[nums.Length];
        var k = 0;
        
        AddAll(x => x % 2 == 0);
        AddAll(x => x % 2 == 1);

        void AddAll(Func<int, bool> condition)
        {
            foreach (var num in nums)
            {
                if (condition(num))
                {
                    result[k++] = num;
                }
            }
        }
        
        return result;
    }
}