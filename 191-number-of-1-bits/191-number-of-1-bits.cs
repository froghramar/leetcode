using System.Runtime.Intrinsics.X86;

public class Solution {
    public int HammingWeight(uint n)
    {
        return (int) Popcnt.PopCount(n);
    }
}