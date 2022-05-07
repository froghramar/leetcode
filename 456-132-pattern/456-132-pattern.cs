public class Solution
{
    public bool Find132pattern(int[] nums)
    {
        var st = new Stack<int>();
        
        var thirdElement = int.MinValue;
        
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            if(nums[i] < thirdElement)
            {
                return true;
            }

            while (st.Any() && st.Peek() < nums[i])
            {
                thirdElement = st.Pop();
            }

            st.Push(nums[i]);
        }
        
        return false;
    }
}
