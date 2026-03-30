public class Solution {
    public int RemoveElement(int[] nums, int val) {
        int nextIndexToCopyTo = 0;
        for(int i = 0; i < nums.Length; i++){
            if(nums[i] != val){
                nums[nextIndexToCopyTo] = nums[i];
                nextIndexToCopyTo++;
            }
        }

        return nextIndexToCopyTo;
    }
}