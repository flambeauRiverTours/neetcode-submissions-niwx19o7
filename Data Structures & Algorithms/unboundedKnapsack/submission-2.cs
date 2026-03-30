public class Solution {
    public int MaximumProfit(List<int> profit, List<int> weight, int capacity) {
        List<int> dp = new List<int>();
        for(int i = 0; i <= capacity; i++){
            dp.Add(0);
        }
        for(int item = 0; item < profit.Count; item++){
            List<int> newRow = new List<int>() {0};
            for(int i = 1; i <= capacity; i++){
                int skip = dp[i];
                int nonskip = 0;
                if(i >= weight[item]){
                    nonskip = profit[item] + newRow[i - weight[item]];
                }
                newRow.Add(Math.Max(skip, nonskip));
            }
            dp = newRow;
        }
        return dp.Last();
    }
}
