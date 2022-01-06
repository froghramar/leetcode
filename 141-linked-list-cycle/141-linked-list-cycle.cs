/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head)
    {
        var current = head;
        var visited = new HashSet<ListNode>();
        while (current != null)
        {
            if (visited.Contains(current))
            {
                return true;
            }
            
            visited.Add(current);
            current = current.next;
        }

        return false;
    }
}