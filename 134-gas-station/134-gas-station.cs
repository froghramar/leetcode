public class Solution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        var n = gas.Length;
        var total = 0;
        var current = 0;
        var start = 0;

        for (var i = 0; i < n; i++)
        {
            total += gas[i] - cost[i];
            current += gas[i] - cost[i];
            if (current < 0)
            {
                current = 0;
                start = i + 1;
            }
        }

        return total < 0 ? -1 : start;
    }
}