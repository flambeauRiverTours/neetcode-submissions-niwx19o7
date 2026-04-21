public class Solution {
    Dictionary<int, List<(int index, int length)>> map = new Dictionary<int, List<(int index, int length)>>();
    public int[] MinInterval(int[][] intervals, int[] queries) {
        for(int i = 0; i < intervals.Length; i++){
            int length = 1 + intervals[i][1] - intervals[i][0];
            for(int j = intervals[i][0]; j <= intervals[i][1]; j++){
                if(!map.ContainsKey(j)){
                    map[j] = new List<(int index, int length)>();
                }
                map[j].Add((i, length));
            }
        }
        foreach(int key in map.Keys){
            map[key] = map[key].OrderBy(x => x.length).ToList();
        }
        int[] result = new int[queries.Length];
        for(int i = 0; i < result.Length; i++){
            if(!map.ContainsKey(queries[i])){
                result[i] = -1;
            }
            else{
                result[i] = map[queries[i]].First().length;
            }
        }
        return result;
    }
}
