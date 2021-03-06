public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        l1 = Reverse(l1);
        l2 = Reverse(l2);
        
        ListNode resultFirst = null;
        ListNode resultLast = null;

        var carriage = 0;
        while (l1 != null || l2 != null)
        {
            var currentSum = GetDigitSum() + carriage;
            var newNode = new ListNode(currentSum % 10);
            carriage = currentSum / 10;

            AddNewNode(newNode);

            int GetDigitSum()
            {
                var currentValue = 0;
                if (l1 != null)
                {
                    currentValue += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    currentValue += l2.val;
                    l2 = l2.next;
                }

                return currentValue;
            }
        }

        if (carriage > 0)
        {
            AddNewNode(new ListNode(carriage));
        }

        void AddNewNode(ListNode newNode)
        {
            if (resultLast == null)
            {
                resultFirst = resultLast = newNode;
            }
            else
            {
                resultLast.next = newNode;
                resultLast = newNode;
            }
        }

        return Reverse(resultFirst);
    }

    private static ListNode Reverse(ListNode head)
    {
        ListNode last = head, current = last.next;
        last.next = null;
        
        while (current != null)
        {
            var currentNext = current.next;
            current.next = last;
            last = current;
            current = currentNext;
        }

        return last;
    }
}