public class Solution {
    public int ThirdMax(int[] nums)
    {
        int first = 0, second = 0, third = 0;
        bool firstFound = false, secondFound = false, thirdFound = false;
        
        foreach (var num in nums)
        {
            if (firstFound is false)
            {
                firstFound = true;
                first = num;
                continue;
            }
            
            if (secondFound is false)
            {
                if (num == first)
                {
                    continue;
                }
                
                secondFound = true;
                second = num;

                if (second > first)
                {
                    (first, second) = (second, first);
                }
                
                continue;
            }

            if (thirdFound is false)
            {
                if (num == first || num == second)
                {
                    continue;
                }

                thirdFound = true;
                Adjust(num);
                
                continue;
            }

            if (num == first || num == second || num == third || num < third)
            {
                continue;
            }
            
            Adjust(num);
        }

        void Adjust(int num)
        {
            third = num;

            if (third > second)
            {
                (second, third) = (third, second);
            }
                
            if (second > first)
            {
                (first, second) = (second, first);
            }
        }

        return thirdFound ? third : first;
    }
}