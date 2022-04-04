public class Solution {
    public ListNode SwapNodes(ListNode head, int k)
    {
        var list = new List<ListNode>();
        var current = head;
        while (current != null)
        {
            list.Add(current);
            current = current.next;
        }

        (list[k - 1].val, list[^k].val) = (list[^k].val, list[k - 1].val);

        return head;
    }
}