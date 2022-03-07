public class Solution {
    public int[] SortedSquares(int[] nums)
    {
        var negatives = new Stack<int>();
        var positives = new Queue<int>();
        
        foreach (var num in nums)
        {
            if (num < 0)
            {
                negatives.Push(-num);
            }
            else
            {
                positives.Enqueue(num);
            }
        }

        var result = new List<int>();

        while (negatives.Any() && positives.Any())
        {
            if (negatives.Peek() < positives.Peek())
            {
                result.Add(GetSquare(negatives.Pop()));
            }
            else
            {
                result.Add(GetSquare(positives.Dequeue()));
            }
        }
        
        while (negatives.Any())
        {
            result.Add(GetSquare(negatives.Pop()));
        }
        
        while (positives.Any())
        {
            result.Add(GetSquare(positives.Dequeue()));
        }

        return result.ToArray();
    }

    private static int GetSquare(int x)
    {
        return x * x;
    }
}