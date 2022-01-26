/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
    {
        var result = new List<int>();

        var leftResult = GetAllElementsSorted(root1);
        var rightResult = GetAllElementsSorted(root2);

        int leftIndex = 0, rightIndex = 0;
        while (leftIndex < leftResult.Count && rightIndex < rightResult.Count)
        {
            if (leftResult[leftIndex] < rightResult[rightIndex])
            {
                result.Add(leftResult[leftIndex++]);
            }
            else
            {
                result.Add(rightResult[rightIndex++]);
            }
        }
        
        while (leftIndex < leftResult.Count)
        {
            result.Add(leftResult[leftIndex++]);
        }
        
        while (rightIndex < rightResult.Count)
        {
            result.Add(rightResult[rightIndex++]);
        }

        return result;
    }

    private IList<int> GetAllElementsSorted(TreeNode node)
    {
        if (node == null)
        {
            return new List<int>();
        }

        var result = new List<int>();
        var leftResult = GetAllElementsSorted(node.left);
        var rightResult = GetAllElementsSorted(node.right);
        
        result.AddRange(leftResult);
        result.Add(node.val);
        result.AddRange(rightResult);

        return result;
    }
}