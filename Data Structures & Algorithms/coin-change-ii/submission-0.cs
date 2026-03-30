public class Solution {
    public int Change(int amount, int[] coins) {
        int count = 0;
        List<int> dp = new List<int>();
        for(int i = 0; i <= amount; i++){
            dp.Add(i == 0 ? 1 : 0);
        }
        for(int coin = 0; coin < coins.Length; coin++){
            for(int i = coins[coin]; i <= amount; i++){
                dp[i] = dp[i] + dp[i - coins[coin]];
            }
        }
        return dp.Last();
    }
}
