public class Solution {
    public int SingleNumber(int[] nums) {
        Dictionary<int, bool> numsDict = new Dictionary<int, bool>();
        foreach(int num in nums){
            if(numsDict.ContainsKey(num)){
                numsDict.Remove(num);
            }
            else{
                numsDict.Add(num, true);
            }
        }
        return numsDict.Keys.ToArray()[0];
    }
}
