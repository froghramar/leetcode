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
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        var totalCount = GetTotalCount(head);
        
        var currentIndex = 0;
        ListNode current = head, lastItemOfPreviousIteration = null, result = null;
        while (currentIndex + k <= totalCount)
        {
            ListNode firstItem = current, lastItem = null;
            
            for (var i = 0; i < k; i++)
            {
                var newCurrent = current.next;
                current.next = lastItem;
                lastItem = current;
                current = newCurrent;

                currentIndex++;
            }

            if (result == null)
            {
                result = lastItem;
            }

            if (lastItemOfPreviousIteration != null)
            {
                lastItemOfPreviousIteration.next = lastItem;
            }
            lastItemOfPreviousIteration = firstItem;
        }
        
        if (lastItemOfPreviousIteration != null)
        {
            lastItemOfPreviousIteration.next = current;
        }

        return result;
    }

    private static int GetTotalCount(ListNode head)
    {
        if (head == null)
        {
            return 0;
        }

        return 1 + GetTotalCount(head.next);
    }
}