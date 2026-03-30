public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int L = 0;
        int R = numbers.Length - 1;
        int sum = numbers[L] + numbers[R];
        while(sum != target){
            if (sum < target){
                L++;
            }
            if(sum > target){
                R--;
            }
            sum = numbers[L] + numbers[R];
        }
        return new int[2]{L + 1, R + 1};
    }
}
