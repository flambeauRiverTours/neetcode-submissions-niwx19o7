public class NumArray {

    public NumArray(int[] nums) {
        prefArray = new int[nums.Length];
        prefArray[0] = nums[0];
        for(int i = 1; i < nums.Length; i++){
            prefArray[i] = prefArray[i - 1] + nums[i];
        }
    }

    int[] prefArray;
    
    public int SumRange(int left, int right) {
        if(left == 0){
            return prefArray[right];
        }
        return prefArray[right] - prefArray[left - 1];
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */