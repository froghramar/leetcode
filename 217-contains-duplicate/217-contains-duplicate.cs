public class Solution {
    public bool ContainsDuplicate(int[] nums)
    {
        var numSet = new HashSet<int>();

        foreach (var num in nums)
        {
            if (numSet.Contains(num))
            {
                return true;
            }

            numSet.Add(num);
        }

        return false;
    }
}