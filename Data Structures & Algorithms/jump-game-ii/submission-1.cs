public class Solution {
    public int Jump(int[] nums) {
        int[] jumps = new int[nums.Length];
        for(int i = 1; i < jumps.Length; i++){
            jumps[i] = -1;
        }
        for(int i = 0; i < (jumps.Length -1); i++){
            if(jumps[i] != -1){
                int currentJumps = jumps[i] +1;
                for(int j = i + 1; j <= (i + nums[i]) && j < nums.Length; j++){
                    if(jumps[j] == -1){
                        jumps[j] = currentJumps;
                    }
                    else if(jumps[j] > currentJumps){
                        jumps[j] = currentJumps;
                    }
                }
            }
        }
        return jumps[jumps.Length - 1];
    }
}
