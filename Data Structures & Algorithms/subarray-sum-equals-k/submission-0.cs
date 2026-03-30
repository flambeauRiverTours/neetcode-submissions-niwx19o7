public class Solution {
    public int SubarraySum(int[] nums, int k) {
        int[] preSum = new int[nums.Length];
        preSum[0] = nums[0];
        for(int i = 1; i < preSum.Length; i++){
            preSum[i] = nums[i] + preSum[i - 1];
        }
        int timesFound = 0;
        for(int i = 0; i < nums.Length; i++){
            if(nums[i] == k) {timesFound++;}
            for(int j = i + 1; j < nums.Length; j++){
                if(i == 0) {
                    if(preSum[j] == k) {timesFound++;}
                }
                else{
                    if((preSum[j] - preSum[i - 1]) == k){timesFound++;}
                }
            }
        }
        return timesFound;
    }
}