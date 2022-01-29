public class Solution {
    public int FindTheWinner(int n, int k)
    {
        Person last = new(n), first = last;
        for (var i = n - 1; i >= 1; i--)
        {
            first = new Person(i, first);
        }

        last.Next = first;
        
        while (last.Next != last)
        {
            var currentLast = last;
            for (var i = 1; i < k; i++)
            {
                currentLast = currentLast.Next;
            }

            currentLast.Next = currentLast.Next.Next;
            last = currentLast;
        }
        
        return last.Val;
    }
}

class Person
{
    public readonly int Val;
    public Person Next;

    public Person(int val, Person next = null)
    {
        Val = val;
        Next = next;
    }
}