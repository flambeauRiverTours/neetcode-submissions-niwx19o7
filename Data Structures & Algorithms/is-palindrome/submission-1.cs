public class Solution {
    public bool IsPalindrome(string s) {
        s = NormalizeString(s);
        int L = 0; int R = s.Length - 1;
        while ((L < R) && (s[L] == s[R])){
            L++;
            R--;
        }

        return L >= R;
    }

    private string NormalizeString(string inputString){
        string resultString = "";
        for(int i = 0; i < inputString.Length; i++){
            if(char.IsLetterOrDigit(inputString[i])){
                resultString += inputString[i];
            }
        }
        return resultString.ToLower();
    }
}