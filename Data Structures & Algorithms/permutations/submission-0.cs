public class Solution {
    public List<List<int>> Permute(int[] nums) {
        return GetPermuts(new List<int>(nums));
    }

    private List<List<int>> GetPermuts(List<int> nums){
        List<List<int>> result = new List<List<int>>();
        if(nums.Count == 1){
            result.Add(new List<int>(){ nums[0]});
            return result;
        }
        for(int i = 0; i < nums.Count; i++){
            int prefix = nums[i];
            List<int> remaining = new List<int>(nums);
            remaining.RemoveAt(i);
            List<List<int>> resultForEach = GetPermuts(remaining);
            foreach(List<int> newResult in resultForEach){
                result.Add(newResult.Prepend(prefix).ToList());
            }
        }
        return result;
    }
}