public class Solution {
    public IList<int> SequentialDigits(int low, int high)
    {
        var result = new List<int>();
        for (var i = 1; i < 10; i++)
        {
            int digit = i, current = 0;
            while (digit <= 9)
            {
                current = current * 10 + digit;

                if (current >= low && current <= high)
                {
                    result.Add(current);
                }
                
                digit++;
            }
        }
        
        result.Sort();

        return result;
    }
}