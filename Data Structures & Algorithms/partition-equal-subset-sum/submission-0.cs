public class Solution {
    public bool CanPartition(int[] nums) {
        return Partition(nums, 0, 0, 0);
    }

    private bool Partition(int[] nums, int index, int sum1, int sum2){
        if(index == nums.Length){
            return sum1 == sum2;
        }
        if(Partition(nums, index + 1, sum1 + nums[index], sum2)){
            return true;
        }

        return Partition(nums, index + 1, sum1, sum2 + nums[index]);
    }
}
