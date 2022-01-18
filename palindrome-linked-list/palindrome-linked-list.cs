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
    public bool IsPalindrome(ListNode head) {
        if (head == null)
        {
            return true;
        }

        var mid = FindMid(head);
        var last = ReverseAfter(mid);
        mid.next = null;

        ListNode headIterator = head, lastIterator = last;
        while (lastIterator != null)
        {
            if (lastIterator.val != headIterator.val)
            {
                return false;
            }

            lastIterator = lastIterator.next;
            headIterator = headIterator.next;
        }

        return true;
    }

    ListNode ReverseAfter(ListNode node)
    {
        ListNode current = node, next = current.next;
        while (next != null)
        {
            var secondNext = next.next;
            next.next = current;
            current = next;
            next = secondNext;
        }

        return current;
    }

    ListNode FindMid(ListNode head)
    {
        ListNode mid = head, current = head;
        var even = true;

        while (current.next != null)
        {
            if (even)
            {
                mid = mid.next;
            }

            current = current.next;
            even = !even;
        }

        return mid;
    }
}