public class Solution {
    public bool ValidMountainArray(int[] arr)
    {
        if (arr.Length < 3 || arr[1] <= arr[0] || arr[^1] >= arr[^2])
        {
            return false;
        }
        
        var increasing = true;
        for (var i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                return false;
            }
            
            if (increasing)
            {
                if (arr[i] < arr[i - 1])
                {
                    increasing = false;
                }
            }
            else
            {
                if (arr[i] > arr[i - 1])
                {
                    return false;
                }
            }
        }

        return true;
    }
}