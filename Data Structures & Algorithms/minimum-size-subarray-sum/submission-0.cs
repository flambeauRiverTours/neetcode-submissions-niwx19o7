public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        int L = 0;
        int minSize = int.MaxValue;
        int currentSum = 0;
        for(int R = 0; R < nums.Length; R++){
            currentSum += nums[R];
            while(currentSum >= target){
                minSize = Math.Min(minSize, R - L + 1);
                currentSum -= nums[L];
                L++;
            }
        }
        return minSize == int.MaxValue ? 0 : minSize;
    }
}