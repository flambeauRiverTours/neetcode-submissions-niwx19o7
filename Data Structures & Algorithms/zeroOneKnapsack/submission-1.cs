public class Solution {
    public int MaximumProfit(List<int> profit, List<int> weight, int capacity) {
        List<int> lastRow = new List<int> {0};
        List<int> currentRow = new List<int>() {0};
        for(int i = 1; i <= capacity; i++){
            if(weight[0] <= i){
                lastRow.Add(profit[0]);
            }
            else{
                lastRow.Add(0);
            }
        }

        for(int i = 1;  i < profit.Count; i++){
            currentRow = new List<int>() {0};
            for(int j = 1; j <= capacity; j++){
                int localProfit = 0;
                if(j - weight[i] >= 0){
                    localProfit = lastRow[j - weight[i]] + profit[i];
                }
                currentRow.Add(Math.Max(lastRow[j], localProfit));
            }
            lastRow = currentRow;
        }
        return currentRow.Last();
    } 
}
