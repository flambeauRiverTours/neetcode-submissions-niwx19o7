public class Solution {
    public bool CanJump(int[] nums) {
        if(nums.Length == 0) {return false;}
        if(nums.Length == 1) {return true;}
        bool[] jumpResults = new bool[nums.Length];
        jumpResults[0] = true;
        for(int i = 0; i < nums.Length; i++){
            if(jumpResults[i]){
                if(i == (nums.Length - 1)){
                    return true;
                }
                int distanceToJump = nums[i];
                for(int j = i + 1; j <= i + distanceToJump; j++){
                    if(j < jumpResults.Length){
                        jumpResults[j] = true;
                    }
                }
            }
        }
        return false;
    }
}
