public class Solution {
    public ListNode SortList(ListNode head) {
        if (head?.next == null)
        {
            return head;
        }

        ListNode mid = head, cur = head.next;
        while (cur != null)
        {
            cur = cur.next;

            if (cur != null)
            {
                cur = cur.next;
                mid = mid.next;
            }
        }

        var first = head;
        var second = mid.next;
        mid.next = null;

        first = SortList(first);
        second = SortList(second);

        ListNode result = null, resultTail = null;

        while (first != null && second != null)
        {
            if (first.val < second.val)
            {
                AddToResult(first);
                first = first.next;
            }
            else
            {
                AddToResult(second);
                second = second.next;
            }
        }

        if (first != null)
        {
            AddToResult(first);
        }

        if (second != null)
        {
            AddToResult(second);
        }

        void AddToResult(ListNode node)
        {
            if (resultTail == null)
            {
                result = resultTail = node;
            }
            else
            {
                resultTail.next = node;
                resultTail = node;
            }
        }
        
        return result;
    }
}