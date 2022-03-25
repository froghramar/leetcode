public class Solution {
    public int TwoCitySchedCost(int[][] costs) {
        Array.Sort(costs, (cost1, cost2) => (cost1[0] - cost1[1]) - (cost2[0] - cost2[1]));
        return costs.Select((cost, index) => index < costs.Length / 2 ? cost[0] : cost[1]).Sum();
    }
}