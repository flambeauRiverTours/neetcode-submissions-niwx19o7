public class Solution {
    SortedDictionary<int, int> intervalDict;
    public int[][] Merge(int[][] intervals) {
        intervalDict = new SortedDictionary<int, int>();
        for(int i = 0; i < intervals.Length; i++){
            if(intervalDict.ContainsKey(intervals[i][0])){
                intervalDict[intervals[i][0]] = Math.Max(intervalDict[intervals[i][0]], intervals[i][1]);
            }
            else{
                intervalDict.Add(intervals[i][0],intervals[i][1]);
            }
        }
        List<int> keys = intervalDict.Keys.ToList();
        for(int i = 1; i < keys.Count; i++){
            int lastKey = keys[i - 1];
            int currentKey = keys[i];
            if(intervalDict[lastKey] >= currentKey){
                intervalDict[lastKey] = Math.Max(intervalDict[lastKey], intervalDict[currentKey]);
                intervalDict.Remove(currentKey);
                keys.RemoveAt(i);
                i--;
            }
        }
        int[][] result = new int[intervalDict.Count][];
        int index = 0;
        foreach(var item in intervalDict){
            result[index++] = new int[] {item.Key, item.Value};
        }
        return result;
    }
}