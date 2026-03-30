public class Solution {
    public int CountSubstrings(string s) {
        
        int numberOfPalindromes = 0;
        bool[,] isPalindromeMap = new bool[s.Length,s.Length];
        for(int stringLength = 0; stringLength < s.Length; stringLength++){
            for(int startIndex = 0; startIndex < s.Length && startIndex + stringLength < s.Length; startIndex++){
                int endIndex = startIndex + stringLength;
                if (s[startIndex] == s[endIndex]){
                    if((endIndex - startIndex) <= 1){
                        numberOfPalindromes++;
                        isPalindromeMap[startIndex,endIndex] = true;
                    }
                    else if(isPalindromeMap[startIndex + 1,endIndex - 1]){
                        numberOfPalindromes++;
                        isPalindromeMap[startIndex, endIndex] = true;
                    }
                }
                
            }
        }

        return numberOfPalindromes;
    }
}
