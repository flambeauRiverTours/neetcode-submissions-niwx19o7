public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] preProd = new int[nums.Length];
        int[] postProd = new int[nums.Length];
        preProd[0] = nums[0];
        for(int i = 1; i < nums.Length; i++){
            preProd[i] = nums[i] * preProd[i - 1];
        }
        postProd[nums.Length - 1] = nums[nums.Length - 1];
        for(int i = nums.Length - 2; i >= 0; i--){
            postProd[i] = postProd[i + 1] * nums[i];
        }

        int[] result =  new int[nums.Length];
        result[0] = postProd[1];
        result[nums.Length - 1] = preProd[nums.Length - 2];
        for(int i = 1; i < (nums.Length - 1); i++){
            result[i] = preProd[i - 1] * postProd[i + 1];
        }
        return result;
    }
}
