public class Solution
{
    public int MaxDistance(int[] position, int m)
    {
        Array.Sort(position);
        int l = 1, r = position[^1] - position[0];
        while (l < r)
        {
            var mid = l + (r - l + 1) / 2;
            if (Check(mid, position, m))
            {
                l = mid;
            }
            else
            {
                r = mid - 1;
            }
        }

        return l;
    }

    private bool Check(int gap, int[] position, int m)
    {
        var begin = position[0];
        var cnt = 1;
        for (var i = 1; i < position.Length; i++)
        {
            if (position[i] - begin >= gap)
            {
                cnt++;
                begin = position[i];
            }
        }

        return cnt >= m;
    }
}