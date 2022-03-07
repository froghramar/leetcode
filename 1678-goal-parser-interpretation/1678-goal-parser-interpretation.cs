public class Solution {
    public string Interpret(string command)
    {
        var res = command.Replace("()", "o");
        res = res.Replace("(al)", "al");
        return res;
    }
}