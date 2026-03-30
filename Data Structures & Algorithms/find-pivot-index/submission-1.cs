public class Solution {
    public int PivotIndex(int[] nums) {
        int[] prefSum = new int[nums.Length];
        int[] postSum =  new int[nums.Length];
        prefSum[0] = nums[0];
        for(int i = 1; i < nums.Length; i++){
            prefSum[i] = nums[i] + prefSum[i - 1];
        }
        postSum[nums.Length - 1] = nums[nums.Length - 1];
        for(int i = nums.Length - 2; i >= 0; i--){
            postSum[i] = nums[i] + postSum[i+1];
        }
        for(int i = 0; i < nums.Length; i++){
            if(postSum[i] == prefSum[i]) {return i;}
        }
        return -1;
    }
}