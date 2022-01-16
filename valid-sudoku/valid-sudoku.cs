public class Solution {
    public bool IsValidSudoku(char[][] board)
    {
        const int dimension = 9, innerDimension = 3;

        for (var dimension1 = 0; dimension1 < dimension; dimension1++)
        {
            var rowElements = new HashSet<int>();
            var columnElements = new HashSet<int>();
            var blockElements = new HashSet<int>();
            
            var blockRow = dimension1 / innerDimension;
            var blockColumn = dimension1 % innerDimension;

            for (var dimension2 = 0; dimension2 < dimension; dimension2++)
            {
                # region checkRows
                
                var rowChar = board[dimension1][dimension2];
                if (rowChar != '.')
                {
                    var rowNumber = rowChar - '0';
                
                    if (rowElements.Contains(rowNumber))
                    {
                        return false;
                    }
                
                    rowElements.Add(rowNumber);
                }

                # endregion
                
                # region checkColumns
                
                var columnChar = board[dimension2][dimension1];
                if (columnChar != '.')
                {
                    var columnNumber = columnChar - '0';
                
                    if (columnElements.Contains(columnNumber))
                    {
                        return false;
                    }
                
                    columnElements.Add(columnNumber);
                }

                # endregion
                
                # region checkBlocks
                
                var innerBlockRow = dimension2 / innerDimension;
                var innerBlockColumn = dimension2 % innerDimension;

                var blockChar = board[blockRow * innerDimension + innerBlockRow][blockColumn * innerDimension + innerBlockColumn];

                if (blockChar != '.')
                {
                    var blockNumber = blockChar - '0';

                    if (blockElements.Contains(blockNumber))
                    {
                        return false;
                    }

                    blockElements.Add(blockNumber);
                }

                # endregion
            }
        }

        return true;
    }
}