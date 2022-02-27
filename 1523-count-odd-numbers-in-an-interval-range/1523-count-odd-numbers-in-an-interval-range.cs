public class Solution {
    public int CountOdds(int low, int high) {
        return (high - low + 1 + (low & 1)) / 2;
    }
}