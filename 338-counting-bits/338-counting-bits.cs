using System.Runtime.Intrinsics.X86;

public class Solution {
    public int[] CountBits(int n)
    {
        return Enumerable.Range(0, n + 1).Select(i => (int)Popcnt.PopCount((uint)i)).ToArray();
    }
}