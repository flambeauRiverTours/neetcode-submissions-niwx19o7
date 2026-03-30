public class Solution {
    public int LastStoneWeightII(int[] stones) {
        int[] lastStones = stones;
        int[] currentStones;
        int totalSum = 0;
        for(int i = 0; i < stones.Length; i++){
            totalSum += stones[i];
        }
        int target = totalSum / 2;
        int[] currentSet;
        int[] lastSet = new int[target + 1];
        for(int i = 0; i < stones.Length; i++){
            currentSet = new int[target + 1];
            for(int j = 0; j <= target; j++){
                if((j >= stones[i]) && (target >= (stones[i] + lastSet[j - stones[i]])))
                {
                    currentSet[j] = Math.Max(lastSet[j], stones[i] + lastSet[j - stones[i]]);
                }
                else{
                    currentSet[j] = lastSet[j];
                }
            }
            lastSet = currentSet;
        }
        return totalSum - (2 * lastSet.Last());
    }
}