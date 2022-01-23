public class Solution {
    public int NthUglyNumber(int n)
    {
        var uglyNumbers = new List<int> { 1 };
        int prevMultipleOfTwoIndex = 0, prevMultipleOfThreeIndex = 0, prevMultipleOfFiveIndex = 0;

        while (--n > 0)
        {
            var nextMultipleOfTwo = uglyNumbers[prevMultipleOfTwoIndex] * 2;
            var nextMultipleOfThree = uglyNumbers[prevMultipleOfThreeIndex] * 3;
            var nextMultipleOfFive = uglyNumbers[prevMultipleOfFiveIndex] * 5;

            var nextUglyNumber = Math.Min(nextMultipleOfTwo, Math.Min(nextMultipleOfThree, nextMultipleOfFive));
            uglyNumbers.Add(nextUglyNumber);

            if (nextUglyNumber == nextMultipleOfTwo)
            {
                prevMultipleOfTwoIndex++;
            }

            if (nextUglyNumber == nextMultipleOfThree)
            {
                prevMultipleOfThreeIndex++;
            }

            if (nextUglyNumber == nextMultipleOfFive)
            {
                prevMultipleOfFiveIndex++;
            }
        }

        return uglyNumbers[^1];
    }
}