public class Solution {
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
    {
        var intersection = new List<int[]>();
        var second = 0;

        for (var first = 0; first < firstList.Length && second < secondList.Length; first++)
        {
            while (second < secondList.Length && firstList[first][1] >= secondList[second][1])
            {
                var (ri, rj) = GetIntersection(first);

                if (rj >= ri)
                {
                    intersection.Add(new[] { ri, rj });
                }
                second++;
            }

            if (second < secondList.Length)
            {
                var (ri, rj) = GetIntersection(first);

                if (rj >= ri)
                {
                    intersection.Add(new[] { ri, rj });
                }
            }
        }

        (int, int) GetIntersection(int first)
        {
            var ri = Math.Max(firstList[first][0], secondList[second][0]);
            var rj = Math.Min(firstList[first][1], secondList[second][1]);
            return (ri, rj);
        }

        return intersection.ToArray();
    }
}