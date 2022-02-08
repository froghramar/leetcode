public class Solution {
    public int AddDigits(int num) {
        while (num > 9)
        {
            num = num.ToString().ToCharArray().Select(ch => ch - '0').Sum();
        }

        return num;
    }
}