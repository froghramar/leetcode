public class Solution {
    public IList<string> FizzBuzz(int n)
    {
        var result = new string[n];

        for (var i = 0; i < n; i++)
        {
            var x = i + 1;
            if (x % 15 == 0)
            {
                result[i] = "FizzBuzz";
            }
            else if (x % 3 == 0)
            {
                result[i] = "Fizz";
            }
            else if (x % 5 == 0)
            {
                result[i] = "Buzz";
            }
            else
            {
                result[i] = x.ToString();
            }
        }
        
        return result;
    }
}