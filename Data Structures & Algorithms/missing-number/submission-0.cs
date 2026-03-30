public class Solution {
    public int MissingNumber(int[] nums) {
        int sum = 0;
        int comparisonSum = 0;
        for(int i = 0; i < nums.Length; i++){
            sum += nums[i];
            comparisonSum += (i + 1);
        }
        return comparisonSum - sum;
    }
}
