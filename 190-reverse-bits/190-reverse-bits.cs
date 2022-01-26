public class Solution {
    public uint reverseBits(uint n) {
        for (var i = 0; i < 16; i++)
        {
            if (GetBit(n, i) != GetBit(n, 31 - i))
            {
                n = AlterBit(n, i);
                n = AlterBit(n, 31 - i);
            }
        }

        return n;
    }

    private int GetBit(uint n, int index)
    {
        return (int) ((n & (1 << index)) >> index);
    }

    private uint AlterBit(uint n, int index)
    {
        return (uint)(n ^ (1 << index));
    }
}