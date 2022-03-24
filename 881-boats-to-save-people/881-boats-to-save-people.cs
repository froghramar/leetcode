public class Solution {
    public int NumRescueBoats(int[] people, int limit)
    {
        Array.Sort(people);
        var result = people.Length;
        int i = 0, j = people.Length - 1;
        while (i < j)
        {
            if (people[i] + people[j] > limit)
            {
                j--;
            }
            else
            {
                i++;
                j--;
                result--;
            }
        }

        return result;
    }
}