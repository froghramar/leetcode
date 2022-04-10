public class Solution {
    public int CalPoints(string[] ops)
    {
        var scores = new int[1005];
        var length = 0;
        foreach (var op in ops)
        {
            switch (op)
            {
                case "+":
                    var sum = scores[length - 1] + scores[length - 2];
                    scores[length++] = sum;
                    break;
                case "D":
                    var dbl = scores[length - 1] * 2;
                    scores[length++] = dbl;
                    break;
                case "C":
                    length--;
                    break;
                default:
                    var val = int.Parse(op);
                    scores[length++] = val;
                    break;
            }
        }

        var res = 0;
        for (var i = 0; i < length; i++)
        {
            res += scores[i];
        }
        return res;
    }
}