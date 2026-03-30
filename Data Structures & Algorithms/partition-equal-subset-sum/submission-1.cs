public class Solution {
    public bool CanPartition(int[] nums) {
        return Partition(nums);
    }

    private bool Partition(int[] nums){
        int target = 0;
        for(int i = 0; i < nums.Length; i++){
            target += nums[i];
        }
        if(target % 2 == 1) {return false;}
        target = target / 2;
        bool[] dp = new bool[target + 1];
        dp[0] = true;
        for(int i = 0; i < nums.Length; i++){
            bool[] nextDP = new bool[target + 1];
            for(int j = 1; j <= target; j++){
                if(j >= nums[i]){
                    nextDP[j] = dp[j] || dp[j - nums[i]];
                }
                else{
                    nextDP[j] = dp[j];
                }
            }
            dp = nextDP;
        }
        return dp[target];
    }
}
