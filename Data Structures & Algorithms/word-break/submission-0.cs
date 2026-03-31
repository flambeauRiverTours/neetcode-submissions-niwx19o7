public class Solution {
    HashSet<string> memo = new HashSet<string>();
    public bool WordBreak(string s, List<string> wordDict) {
        if(s == "") {return true;}
        if(memo.Contains(s)) {return false;}
        foreach(string startword in wordDict){
            if(s.StartsWith(startword)){
                string newWord = s.Substring(startword.Length);
                if(WordBreak(newWord, wordDict)){
                    return true;
                }
                memo.Add(newWord);
            }
        }
        return false;
    }

}
