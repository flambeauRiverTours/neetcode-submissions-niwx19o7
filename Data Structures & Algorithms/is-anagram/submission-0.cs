public class Solution {
    public bool IsAnagram(string s, string t) {
        if(t.Length != s.Length) {return false;}
        Dictionary<char, int> charUsageDict = new Dictionary<char, int>();
        for(int i = 0; i < s.Length; i++){
            if(!charUsageDict.ContainsKey(s[i])){
                charUsageDict[s[i]] = 1;
            }
            else{
                charUsageDict[s[i]]++;
            }
        }
        for(int i = 0; i < t.Length; i++){
            if(!charUsageDict.ContainsKey(t[i])){
                return false;
            }
            charUsageDict[t[i]]--;
            if(charUsageDict[t[i]] == 0){
                charUsageDict.Remove(t[i]);
            }
        }
        return true;
    }
}
