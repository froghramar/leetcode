public class Solution {
    public bool CanMakeArithmeticProgression(int[] arr) {
        Array.Sort(arr);

        for (var i = 2; i < arr.Length; i++)
        {
            if (arr[i] - arr[i - 1] != arr[1] - arr[0])
            {
                return false;
            }
        }

        return true;
    }
}