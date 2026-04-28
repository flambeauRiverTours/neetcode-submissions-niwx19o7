public class Solution {
    public bool IsMatch(string s, string p) {
        List<char> expQueue = new List<char>();
        foreach(char exp in p.ToCharArray()){
            expQueue.Add(exp);
        }
        return RegexMatches(s.ToCharArray(),0,expQueue);
    }

    private bool RegexMatches(char[] letters, int index, List<char> expQueue){
        if(index == letters.Length) {
            if(expQueue.Count == 0){
                return true;
            }
            if((expQueue.Count % 2) == 0){
                for(int i = 1; i < expQueue.Count; i = i + 2){
                    if(expQueue[i] != '*') {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        if(expQueue.Count == 0) {return index == letters.Length;}
        char exp = expQueue[0];
        char precChar = '!';
        if((expQueue.Count > 1) && (expQueue[1] == '*')){
            precChar = exp;
            exp = '*';
        }
        switch(exp){
            case '.':
                expQueue.RemoveAt(0);
                if(RegexMatches(letters, index + 1, expQueue)){
                    return true;
                }
                expQueue.Insert(0, exp);
                break;
            case '*':
                if((letters[index] == precChar) || (precChar == '.')){
                    if(RegexMatches(letters, index+1, expQueue)){
                        return true;
                    }
                    expQueue.RemoveAt(0);
                    expQueue.RemoveAt(0);
                    if(RegexMatches(letters, index + 1, expQueue)){
                        return true;
                    }
                    if(RegexMatches(letters, index, expQueue)){
                        return true;
                    }
                    expQueue.Insert(0, exp);
                    expQueue.Insert(0, precChar);
                }
                else 
                {
                    expQueue.RemoveAt(0);
                    expQueue.RemoveAt(0);
                    if(RegexMatches(letters, index, expQueue)){
                        return true;
                    }
                    expQueue.Insert(0, exp);
                    expQueue.Insert(0, precChar);
                }
                break;
            default:
                if(letters[index] == exp){
                    expQueue.RemoveAt(0);
                    if(RegexMatches(letters, index + 1, expQueue)){
                        return true;
                    }
                    expQueue.Insert(0, exp);
                }
                else{
                    return false;
                }
                break;
        }
        return false;
    }
}
