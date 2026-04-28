public class Solution {
    public string MinWindow(string s, string t) {
        if(s.Length < t.Length) {return "";}
        if((t == "") || (s == "")) {return "";}
        int firstPointer = 0;
        int length = t.Length;
        string result = "";
        while((firstPointer + length) <= s.Length){
            string newString= s.Substring(firstPointer, length);
            if(AllCharsPres(newString, t)){
                if(result == ""){
                    result = newString;
                }
                else if(newString.Length < result.Length){
                    result = newString;
                }
                if(result.Length == t.Length){
                    return result;
                }
                firstPointer++;
                length--;
            }
            else{
                length++;
            }   
        }
        return result;
    }

    private bool AllCharsPres(string substr, string t){
        if(substr.Length < t.Length) {return false;}
        foreach(char letter in t.ToCharArray()){
            int index = substr.IndexOf(letter);
            if(index == -1){
                return false;
            }
            substr = substr.Remove(index, 1);
        }
        return true;
    }
}
