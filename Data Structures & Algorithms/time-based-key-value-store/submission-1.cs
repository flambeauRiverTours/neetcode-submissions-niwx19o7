public class TimeMap {

    public TimeMap() {
        keyToTimeToValMap = new Dictionary<string, SortedDictionary<int, string>>();
    }
    Dictionary<string, SortedDictionary<int, string>> keyToTimeToValMap;
    public void Set(string key, string value, int timestamp) {
        if(!keyToTimeToValMap.ContainsKey(key)){
            keyToTimeToValMap.Add(key, new SortedDictionary<int, string>() {{timestamp, value}});
        }
        else{
            keyToTimeToValMap[key].Add(timestamp, value);
        }
    }
    
    public string Get(string key, int timestamp) {
        if(!keyToTimeToValMap.ContainsKey(key)){ return ""; }
        IEnumerable<int> potentialKeys = keyToTimeToValMap[key].Keys.Where(x => x <= timestamp);
        if(potentialKeys.Count() == 0) {return "";}
        int targetTimeStamp = potentialKeys.Last();
        return keyToTimeToValMap[key][targetTimeStamp];
    }
}
