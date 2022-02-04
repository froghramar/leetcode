public class Solution {
    public int RangeBitwiseAnd(int left, int right)
    {
        int result = 0, mask = left;

        for (var i = 0; i < 31; i++)
        {
            if (HasBit(mask, i) is false)
            {
                mask = SetBit(mask, i);
            }
            
            if (HasBit(left, i) && right <= mask)
            {
                result = SetBit(result, i);
            }
        }
        
        return result;
    }

    private static bool HasBit(int x, int i)
    {
        return (x & (1 << i)) > 0;
    }

    private static int SetBit(int x, int i)
    {
        return x + (1 << i);
    }
}