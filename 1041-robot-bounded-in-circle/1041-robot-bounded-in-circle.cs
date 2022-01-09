public class Solution
{
    public bool IsRobotBounded(string instructions)
    {
        int row = 0, column = 0, direction = 0;
        foreach (var ch in instructions)
            switch (ch)
            {
                case 'L':
                    direction = (direction + 1) % 4;
                    break;
                case 'R':
                    direction = (direction - 1 + 4) % 4;
                    break;
                case 'G':
                {
                    switch (direction)
                    {
                        case 0:
                            column++;
                            break;
                        case 1:
                            row--;
                            break;
                        case 2:
                            column--;
                            break;
                        default:
                            row++;
                            break;
                    }

                    break;
                }
            }

        return direction != 0 || row == 0 && column == 0;
    }
}