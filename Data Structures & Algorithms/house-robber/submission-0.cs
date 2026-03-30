public class Solution {
    public int Rob(int[] nums) {
        int[] money = [0, 0];
        for(int i = 0; i < nums.Length; i++){
            int temp = money[1];
            money[1] = Math.Max(money[0] + nums[i], money[1]);
            money[0] = temp;
        }

        return Math.Max(money[0], money[1]);
    }
}
