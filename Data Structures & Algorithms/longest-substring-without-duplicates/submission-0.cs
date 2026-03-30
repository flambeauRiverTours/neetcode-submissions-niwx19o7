public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if(s == "") {return 0;}
        HashSet<char> currentChars = new HashSet<char>();
        int L = 0;
        int longestSet = 1;
        for(int R = 0; R < s.Length; R++){
            while(currentChars.Contains(s[R])){
                currentChars.Remove(s[L]);
                L++;
            }
            currentChars.Add(s[R]);
            longestSet = Math.Max(longestSet, currentChars.Count);
        }
        return longestSet;
    }
}
