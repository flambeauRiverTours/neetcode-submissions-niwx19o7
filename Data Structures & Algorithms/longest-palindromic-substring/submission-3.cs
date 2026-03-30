public class Solution {
    public string LongestPalindrome(string s) {
        Stack<char> charStack = new Stack<char>();
        int maxPalindrome = 0;
        string maxPalindromeString = "";
        Dictionary<char, List<int>> charToIndexMap = new Dictionary<char, List<int>>();
        for(int i = 0; i < s.Length; i++){
            if(charToIndexMap.ContainsKey(s[i])){
                foreach(int charIndex in charToIndexMap[s[i]]){
                    if ((((i - charIndex) + 1) > maxPalindrome) && IsPalindromeBetween(s, charIndex, i)){
                        maxPalindrome = (i - charIndex) + 1;
                        maxPalindromeString = s.Substring(charIndex, maxPalindrome);
                    }
                }
                charToIndexMap[s[i]].Add(i);
            }
            else{
                charToIndexMap.Add(s[i], new List<int>(){i});
            }
        }
        if((maxPalindrome == 0) && (s.Length > 0)){
            return s.Substring(0,1);
        }
        return maxPalindromeString;
    }

    private  bool IsPalindromeBetween(string s, int index1, int index2){
        while(index1 < index2){
            if(s[index1] != s[index2]){
                return false;
            }
            index1++;
            index2--;
        }
        return true;
    }
}
