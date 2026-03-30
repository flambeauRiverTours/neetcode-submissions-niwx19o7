public class Solution {
    List<List<int>> resultListOfLists = new List<List<int>>();
    public List<List<int>> Subsets(int[] nums) {
        var res = new List<List<int>>();
        var subset = new List<int>();
        GetSubsetsForIndex(nums, 0, subset, res);
        return res;
    }

    public void GetSubsetsForIndex(int[] nums, int i, List<int> subset, List<List<int>> result){
        if(i >= nums.Length) {
            result.Add(new List<int>(subset));
            return;
        }
        subset.Add(nums[i]);
        GetSubsetsForIndex(nums, i + 1, subset, result);
        subset.RemoveAt(subset.Count - 1);
        GetSubsetsForIndex(nums, i + 1, subset, result);
    }
}
