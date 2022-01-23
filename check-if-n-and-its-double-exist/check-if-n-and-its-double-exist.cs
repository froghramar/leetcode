public class Solution {
    public bool CheckIfExist(int[] arr)
    {
        for (var i = 0; i < arr.Length; i++)
        {
            for (var j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] == 2 * arr[j] || arr[j] == 2 * arr[i])
                {
                    return true;
                }
            }
        }
        return false;
    }
}