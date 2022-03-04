public class Solution
{
    public double ChampagneTower(int poured, int query_row, int query_glass)
    {
        var currentRow = new double[] { poured };
        var previousRow = currentRow;

        for (var i = 0; i < query_row; i++)
        {
            currentRow = new double[previousRow.Length + 1];

            for (var j = 0; j < previousRow.Length; j++)
            {
                if (previousRow[j] > 1.0)
                {
                    var spillToTwoGlasses = (previousRow[j] - 1.0) / 2.0;
                    currentRow[j] += spillToTwoGlasses;
                    currentRow[j + 1] += spillToTwoGlasses;
                }
            }

            previousRow = currentRow;
        }

        return Math.Min(1.0, currentRow[query_glass]);
    }
}