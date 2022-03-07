public class Solution
{

    private bool[] _visited;
    
    public void Rotate(int[] nums, int k)
    {
        _visited = new bool[nums.Length];

        for (var index = 0; index < nums.Length; index++)
        {
            StartSwap((index + k) % nums.Length, nums, k, nums[index]);
        }
    }

    private void StartSwap(int index, int[] nums, int k, int newValue)
    {
        if (_visited[index])
        {
            return;
        }

        _visited[index] = true;

        var current = nums[index];

        nums[index] = newValue;
        
        StartSwap((index + k) % nums.Length, nums, k, current);
    }
}