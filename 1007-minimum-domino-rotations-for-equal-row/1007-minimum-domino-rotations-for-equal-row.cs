public class Solution {
    public int MinDominoRotations(int[] tops, int[] bottoms)
    {
        var topCount = new int[6];
        var bottomCount = new int[6];
        var allCount = new int[6];

        for (var i = 0; i < tops.Length; i++)
        {
            if (tops[i] == bottoms[i])
            {
                allCount[tops[i] - 1]++;
            }
            else
            {
                topCount[tops[i] - 1]++;
                bottomCount[bottoms[i] - 1]++;
            }
        }

        var result = int.MaxValue;
        for (var i = 0; i < 6; i++)
        {
            if (topCount[i] + bottomCount[i] + allCount[i] == tops.Length)
            {
                result = Math.Min(result, Math.Min(topCount[i], bottomCount[i]));
            }
        }
        
        return result == int.MaxValue ? -1 : result;
    }
}