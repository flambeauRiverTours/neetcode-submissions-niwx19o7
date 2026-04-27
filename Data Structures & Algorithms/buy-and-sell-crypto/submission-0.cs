public class Solution {
    public int MaxProfit(int[] prices) {
        int lowestPrice = Int32.MaxValue;
        int currentProfit = 0;
        for(int i = 0; i < prices.Length; i++){
            if(prices[i] < lowestPrice){
                lowestPrice = prices[i];
            }
            else{
                currentProfit = Math.Max(currentProfit, prices[i] - lowestPrice);
            }
        }
        return currentProfit;
    }
}
