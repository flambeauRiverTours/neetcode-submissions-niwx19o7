public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> dictValToIndex = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++){
            int diffCurrentNumAndTarget = target - nums[i];
            if(dictValToIndex.Keys.Contains(diffCurrentNumAndTarget)){
                return [dictValToIndex[diffCurrentNumAndTarget], i];
            }
            dictValToIndex.Add(nums[i], i);
        }
        throw new Exception("Failed to find a match. Problem condition violated or code issue present");
    }
}
