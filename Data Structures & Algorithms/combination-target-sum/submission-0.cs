public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {
        List<List<int>> result = new List<List<int>>();
        Stack<int> currentSum = new Stack<int>();
        DFSComboSum(nums, 0, target , currentSum, result);
        return result;
    }

    public void DFSComboSum(int[] nums, int index, int target, Stack<int> currentSum, List<List<int>> result){
        if((target == 0) && (currentSum.Count > 0)) {
            result.Add(new List<int>(currentSum));
        }
        if(target < 0){
            return;
        }
        for(int i = index; i < nums.Length; i++){
            target -= nums[i];
            currentSum.Push(nums[i]);
            DFSComboSum(nums, i, target, new Stack<int>(currentSum), result);
            target += nums[i];
            currentSum.Pop();
        }

    }
}
