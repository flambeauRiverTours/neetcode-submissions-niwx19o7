public class Solution {
    public int MaxCoins(int[] nums) {
        return MaxCoinsInt(new List<int>(nums));
    }
    Dictionary<string,int> resultDict = new Dictionary<string, int>();
    private int MaxCoinsInt(List<int> nums){
        string key = string.Join(",", nums);
        if(resultDict.ContainsKey(key)){
            return resultDict[key];
        }
        int maxVal = 0;
        for(int i = 0; i < nums.Count; i++){

            int tempVal = nums[i];
            int origVal = nums[i];
            if(i > 0){
                tempVal = tempVal * nums[i - 1];
            }
            if(i < (nums.Count - 1)){
                tempVal = tempVal * nums[i + 1];
            }
            nums.RemoveAt(i);
            tempVal += MaxCoinsInt(nums);
            if(tempVal > maxVal){
                maxVal = tempVal;
            }
            nums.Insert(i, origVal);
        }
        resultDict[key] = maxVal;
        return maxVal;
    }
}
