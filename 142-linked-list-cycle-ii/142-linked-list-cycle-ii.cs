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
    public ListNode DetectCycle(ListNode head)
    {
        var visited = new HashSet<ListNode>();
        var current = head;
        while (current !=  null)
        {
            if (visited.Contains(current))
            {
                return current;
            }

            visited.Add(current);
            current = current.next;
        }

        return null;
    }
}