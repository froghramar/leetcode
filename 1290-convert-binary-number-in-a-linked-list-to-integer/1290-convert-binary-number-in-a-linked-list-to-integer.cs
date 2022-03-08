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
    public int GetDecimalValue(ListNode head)
    {
        var result = 0;
        var current = head;
        while (current != null)
        {
            result = (result << 1) + current.val;
            current = current.next;
        }
        
        return result;
    }
}