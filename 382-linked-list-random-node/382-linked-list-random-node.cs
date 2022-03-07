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
public class Solution
{
    private List<int> _numbers;
    private Random _random;
    public Solution(ListNode head)
    {
        _numbers = new List<int>();
        _random = new Random();

        var current = head;
        while (current != null)
        {
            _numbers.Add(current.val);
            current = current.next;
        }
    }
    
    public int GetRandom()
    {
        var randomIndex = _random.Next(_numbers.Count);
        return _numbers[randomIndex];
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(head);
 * int param_1 = obj.GetRandom();
 */