public class Solution {

    Dictionary<int, int> parents;
    Dictionary<int, int> rank;
    Dictionary<int, int> numToIndexDict;
    public int LongestConsecutive(int[] nums) {
        if (nums.Length == 0) return 0;
        parents = new Dictionary<int, int>();
        rank = new Dictionary<int, int>();
        numToIndexDict = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++){
            if (numToIndexDict.ContainsKey(nums[i])) continue;
            parents[i] = i;
            rank[i] = 0;
            numToIndexDict[nums[i]] = i;
        }
        for(int i = 0; i < nums.Length; i++){
            if(numToIndexDict.ContainsKey(nums[i] - 1)){
                Union(numToIndexDict[nums[i]], numToIndexDict[nums[i] - 1]);
            }
        }
        Dictionary<int, int> parentToCount = new Dictionary<int, int>();
        int maxParent = 0;
        HashSet<int> seenNumbers = new HashSet<int>();
        for(int i = 0; i < nums.Length; i++){
            if (seenNumbers.Contains(nums[i])) continue;
            seenNumbers.Add(nums[i]);
            int parent = Find(numToIndexDict[nums[i]]);
            if(!parentToCount.ContainsKey(parent)){
                parentToCount[parent] = 0;
            }
            parentToCount[parent] += 1;
            if(parentToCount[parent] > maxParent){
                maxParent = parentToCount[parent];
            }
        }
        return maxParent;

    }

    private int Find(int n){
        while(n != parents[n]){
            parents[n] = parents[parents[n]];
            n = parents[n];
        }
        return n;
    }

    private bool Union(int n1, int n2){
        int p1 = Find(n1);
        int p2 = Find(n2);
        if(p1 == p2){
            return false;
        }
        if(rank[p1] > rank[p2]){
            parents[p2] = p1;
        } 
        else if(rank[p2] > rank[p1]){
            parents[p1] = p2;
        }
        else{
            parents[p2] = p1;
            rank[p1] += 1;
        }
        return true;
    }

}