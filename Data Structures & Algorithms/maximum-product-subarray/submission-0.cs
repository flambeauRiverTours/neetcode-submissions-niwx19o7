public class Solution {
    public int MaxProduct(int[] nums) {
        int max = 1;
        int min = 1;
        int resultMax = nums[0];
        for(int i = 0; i < nums.Length; i++){
            if(nums[i] == 0){
                max = 1;
                min = 1;
                if(0 > resultMax) resultMax = 0;
                continue;
            }
            int currMax = nums[i] * max;
            int currMin = nums[i] * min;
            
            max = Math.Max(nums[i], Math.Max(currMax, currMin));
            min = Math.Min(nums[i], Math.Min(currMax, currMin));

            if(max > resultMax){
                resultMax = max;
            }
        }
        return resultMax;
    }
}