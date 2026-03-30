public class Solution {
    public int MaxSubArray(int[] nums) {
        int max = 0;
        int sum = 0;
        for(int i = 0; i < nums.Length; i++){
            if(i == 0){
                sum = nums[i];
                max = nums[i];
            }
            else{
                sum += nums[i];
                max = Math.Max(sum, max);
            }
            sum = Math.Max(0, sum);
        }
        return max;
    }
}
