public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        HashSet<int> intsInWindow = new HashSet<int>();
        for(int i = 0; i < nums.Length; i++){
            if(intsInWindow.Contains(nums[i])){
                return true;
            }
            intsInWindow.Add(nums[i]);
            int indexToRemove = i - k;
            if(indexToRemove >= 0){
                intsInWindow.Remove(nums[indexToRemove]);
            }
        }
        return false;
    }
}