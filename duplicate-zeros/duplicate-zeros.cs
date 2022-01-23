public class Solution {
    public void DuplicateZeros(int[] arr) {
        for (var i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] != 0)
            {
                continue;
            }
            
            for (var j = arr.Length - 1; j >= i + 1; j--)
            {
                arr[j] = arr[j - 1];
            }

            i++;
        }
    }
}