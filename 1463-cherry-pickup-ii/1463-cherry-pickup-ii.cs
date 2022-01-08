public class Solution {
    public int CherryPickup(int[][] grid)
    {
        var numberOfRows = grid.Length;
        var numberOfColumns = grid[0].Length;
        var dp = new int[numberOfRows + 1, numberOfColumns + 1, numberOfColumns + 1];

        for (var row = numberOfRows - 1; row >= 0; row--)
        {
            for (var robot1Column = numberOfColumns - 1; robot1Column >= 0; robot1Column--)
            {
                for (var robot2Column = numberOfColumns - 1; robot2Column >= 0; robot2Column--)
                {
                    var current = grid[row][robot1Column] + (robot1Column == robot2Column ? 0 : grid[row][robot2Column]);
                    var nextResult = 0;

                    for (var robot1Diff = -1; robot1Diff <= 1; robot1Diff++)
                    {
                        for (var robot2Diff = -1; robot2Diff <= 1; robot2Diff++)
                        {
                            var robot1NewColumn = robot1Column + robot1Diff;
                            var robot2NewColumn = robot2Column + robot2Diff;

                            if (IsInRange(robot1NewColumn, numberOfColumns) &&
                                IsInRange(robot2NewColumn, numberOfColumns))
                            {
                                nextResult = Math.Max(nextResult, dp[row + 1, robot1NewColumn, robot2NewColumn]);
                            }
                        }
                    }

                    dp[row, robot1Column, robot2Column] = current + nextResult;
                }
            }
        }
        
        return dp[0, 0, numberOfColumns - 1];
    }

    private static bool IsInRange(int index, int numberOfColumns)
    {
        return index >= 0 && index <= numberOfColumns;
    }
}