public class Solution {
    public int MaxProfit(int[] _prices) {
        prices = _prices;
        return MPInt(0, 0, true);
    }

    int[] prices;
    Dictionary<(int, int, bool), int> memo = new Dictionary<(int, int, bool), int>();
    private int MPInt(int index, int buyPrice, bool buying){
        if(index >= prices.Length) {return 0;}
        if(memo.ContainsKey((index, buyPrice, buying))) {return memo[(index, buyPrice, buying)];}
        int result = 0;
        if(buying){
            result = Math.Max(MPInt(index + 1, prices[index], false), MPInt(index + 1, 0, true));
        }
        else{
            result = Math.Max(prices[index] - buyPrice + MPInt(index + 2, 0, true), MPInt(index + 1, buyPrice, false));
        }
        memo[(index, buyPrice, buying)] = result;
        return result;
    }
}
