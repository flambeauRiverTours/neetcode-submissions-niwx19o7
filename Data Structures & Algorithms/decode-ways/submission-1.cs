public class Solution {
    Dictionary<string, int> map;
    public int NumDecodings(string s) {
        map = new Dictionary<string, int>();
        if(s.Length == 0) {return 0;}
        return Branch(s);
    }

    private int Branch(string s){
        if(s.Length == 0) {return 1;}
        if(s.Length == 1) {return s != "0" ? 1 : 0;}
        if(map.ContainsKey(s)) {return map[s];}
        Int32.TryParse(s[0].ToString(), out int first);
        if(first == 0) {return 0;}
        int res;
        if(first > 2){
            res = Branch(s.Substring(1));
        }
        else{
            Int32.TryParse(s[1].ToString(), out int next);
            if(((first * 10) + next) < 27){
                res = Branch(s.Substring(1)) + Branch(s.Substring(2));
            }
            else{
                res = Branch(s.Substring(1));
            }
        }
        map[s] = res;
        return res;
    }
}
