public class Solution {
    public int ClimbStairs(int n) {     

        int[] array = [0, 1];

        for(int i = 1; i <= n; i++){
            int temp = array[1];
            array[1] = array[0] + array[1];
            array[0] = temp;
        }

        return array[1];
    }
}
