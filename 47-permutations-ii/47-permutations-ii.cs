public class Solution {
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        var result = new List<IList<int>>();
        Traverse(nums, new List<int>(), result);

        return result;
    }

    void Traverse(int[] nums, IList<int> current, IList<IList<int>> result)
    {
        var visited = new bool[21];
        var end = true;
        
        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            if (num == int.MaxValue || visited[num + 10])
            {
                continue;
            }

            end = false;
            nums[i] = int.MaxValue;
            visited[num + 10] = true;
            
            var next = current.ToList();
            next.Add(num);
            
            Traverse(nums, next, result);

            nums[i] = num;
        }

        if (end)
        {
            result.Add(current.ToList());
        }
    }
}