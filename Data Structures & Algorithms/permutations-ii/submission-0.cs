public class Solution {
    public List<List<int>> PermuteUnique(int[] nums) {
        List<List<int>> perms = new List<List<int>>();
        perms.Add(new List<int>());
        foreach(int n in nums){
            HashSet<string> seen = new HashSet<string>();
            List<List<int>> nextPerms = new List<List<int>>();
            foreach(List<int> p in perms){
                for(int i = 0; i <= p.Count; i++){
                    List<int> pCopy = new List<int>(p);
                    pCopy.Insert(i, n);
                    string s = string.Join(",", pCopy);
                    if (!seen.Contains(s)) {
                        nextPerms.Add(pCopy);
                        seen.Add(s);
                    }
                }
            }
            perms = nextPerms;
        }
        return perms;
    }
}