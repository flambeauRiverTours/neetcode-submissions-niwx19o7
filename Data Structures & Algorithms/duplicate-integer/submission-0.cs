public class Solution {

    public bool hasDuplicate(int[] nums) {
            HashSet<int> numHashSet = new HashSet<int>();
            foreach(int num in nums){
                if(numHashSet.Contains(num)) {
                    return true;
                }
                numHashSet.Add(num);
            }
            return false;
    }
}