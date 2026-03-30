public class Solution {
    public int MincostTickets(int[] days, int[] costs) {
        List<int> weights = new List<int>(){1, 7, 30};
        return UBDP(days.ToList(), costs.ToList(), weights, days[days.Length - 1]);
    }

    private int UBDP(List<int> days, List<int> costs, List<int> weights, int capacity){
        List<int> dp = new List<int>(){0};
        
        for(int i = 1; i <= 365; i++){
            if(!days.Contains(i)){
                dp.Add(dp.Last());
            }
            else{
                int min1 = Math.Min(dp[i - 1] + costs[0], dp[Math.Max(0, i -7)] + costs[1]);
                dp.Add(Math.Min(min1, dp[Math.Max(0,i-30)] + costs[2]));
            }
        }

        return dp.Last();
    }
}