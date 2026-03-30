public class Solution {
    public int MaxSubarraySumCircular(int[] nums) {
        int totalSum = 0;
        int currMax = 0, maxSub = int.MinValue;
        int currMin = 0, minSub = int.MaxValue;

        foreach (int x in nums) {
            totalSum += x;
            currMax = Math.Max(x, currMax + x);
            maxSub = Math.Max(maxSub, currMax);
            currMin = Math.Min(x, currMin + x);
            minSub = Math.Min(minSub, currMin);
        }

        return maxSub > 0 ? Math.Max(maxSub, totalSum - minSub) : maxSub;
    }
}