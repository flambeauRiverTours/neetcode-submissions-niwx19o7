public class Solution {
    public int CharacterReplacement(string s, int k) {
        Dictionary<char, int> charsInWindow = new Dictionary<char, int>();
        int L = 0;
        int maxWindow = 0;
        for(int R = 0; R < s.Length; R++){
            if(!charsInWindow.ContainsKey(s[R])){
                charsInWindow.Add(s[R], 1);
            }
            else{
                charsInWindow[s[R]]++;
            };
            
            while(SumOtherKeys(charsInWindow, GetMaxChar(charsInWindow)) > k){
                charsInWindow[s[L]]--;
                L++;
            }
            maxWindow = Math.Max(maxWindow, (R - L) + 1);
        }
        return maxWindow;
    }
    
    private char GetMaxChar(Dictionary<char, int> dict){
        char maxChar = ' ';
        int maxVal = -1;
        foreach(var kvp in dict){
            if(kvp.Value > maxVal){
                maxVal = kvp.Value;
                maxChar = kvp.Key;
            }
        }
        return maxChar;
    }

    private int SumOtherKeys(Dictionary<char, int> charsInWindow, char keyToSkip){
        int sum = 0;
        foreach(char key in charsInWindow.Keys){
            if(key != keyToSkip){
                sum += charsInWindow[key];
            }
        }
        return sum;
    }
}