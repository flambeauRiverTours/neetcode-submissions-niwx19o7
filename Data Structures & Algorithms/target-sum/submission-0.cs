public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {
        int sum = 0;
        foreach (int n in nums) sum += n;
        if (Math.Abs(target) > sum) return 0;

        int offset = sum;
        int[] lastRow = new int[2 * sum + 1];
        lastRow[offset] = 1;

        for (int i = 0; i < nums.Length; i++) {
            int[] currentRow = new int[2 * sum + 1];
            for (int j = 0; j < lastRow.Length; j++) {
                if (lastRow[j] > 0) {
                    currentRow[j + nums[i]] += lastRow[j];
                    currentRow[j - nums[i]] += lastRow[j];
                }
            }
            lastRow = currentRow;
        }

        return lastRow[target + offset];
    }
}
