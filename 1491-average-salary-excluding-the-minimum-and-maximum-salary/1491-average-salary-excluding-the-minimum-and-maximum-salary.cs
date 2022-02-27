public class Solution {
    public double Average(int[] salary)
    {
        return (salary.Sum() - salary.Max() - salary.Min()) / (double)(salary.Length - 2);
    }
}