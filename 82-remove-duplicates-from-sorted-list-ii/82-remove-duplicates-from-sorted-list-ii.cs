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
    public ListNode DeleteDuplicates(ListNode head)
    {
        ListNode prev = null, result = null;
        var current = head;

        while (current?.next != null)
        {
            if (current.val != current.next.val)
            {
                AddToList(current.val);
                current = current.next;
                continue;
            }

            var next = current.next;
            while (next != null && next.val == current.val)
            {
                next = next.next;
            }

            current = next;
        }

        if (current != null)
        {
            AddToList(current.val);
        }

        void AddToList(int val)
        {
            if (prev == null)
            {
                prev = result = new ListNode(val);
            }
            else
            {
                prev.next = new ListNode(val);
                prev = prev.next;
            }
        }

        return result;
    }
}