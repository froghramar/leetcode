public class Solution {
    public IList<int> GrayCode(int n)
    {
        var result = new List<int>{ 0 } ;

        for (var i = 0; i < n; i++)
        {
            var len = result.Count;
            for (var j = len - 1; j >= 0; j--)
            {
                result.Add(SetBit(result[j], i));
            }
        }
        
        return result;
    }

    private int SetBit(int n, int i)
    {
        return n | (1 << i);
    }
}