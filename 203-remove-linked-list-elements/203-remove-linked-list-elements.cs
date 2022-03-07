/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode RemoveElements(ListNode head, int val)
    {
        if (head == null)
        {
            return null;
        }
        
        ListNode previous = null, current = head, result = null;

        while (current != null)
        {
            if (current.val != val)
            {
                if (result == null)
                {
                    result = current;
                }
                
                previous = current;
                current = current.next;
            }
            else
            {
                current = current.next;
                if (previous != null)
                {
                    previous.next = current;
                }
            }
        }
        
        return result;
    }
}