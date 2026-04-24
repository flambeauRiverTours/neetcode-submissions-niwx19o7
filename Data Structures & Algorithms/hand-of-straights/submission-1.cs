public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        SortedDictionary<int, int> sortedDict = new SortedDictionary<int, int>();
        if((hand.Length % groupSize) != 0) {return false;}
        foreach(int card in hand){
            if(!sortedDict.ContainsKey(card)){
                sortedDict[card] = 0;
            }
            sortedDict[card]++;
        }
        while(sortedDict.Count > 0){
            int nextKey = sortedDict.Keys.First();
            if(!Recurse(nextKey, sortedDict, groupSize)){
                return false;
            }
        }
        return true;
    }

    private bool Recurse(int key, SortedDictionary<int, int> sortedDict, int groupSize){
        if(groupSize == 0) {return true;}
        if(!sortedDict.ContainsKey(key)) {return false;}
        sortedDict[key]--;
        if(sortedDict[key] == 0) {
            sortedDict.Remove(key);
        }
        return Recurse(key + 1, sortedDict, groupSize - 1);
    }
}
