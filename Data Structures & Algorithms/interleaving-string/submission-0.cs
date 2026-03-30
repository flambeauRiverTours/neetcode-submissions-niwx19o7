public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {
        int combinedLength = s1.Length + s2.Length;
        if(combinedLength != s3.Length) {return false;}
        if(s1 == "") {return s2 == s3;}
        if(s2 == "") {return s1 == s3;}
        return InterleaveInt(s1, s2, s3);
    }

    public bool InterleaveInt(string s1, string s2, string s3){
        if(s3 == "") {return true;}
        if((s2.Length > 0) && (s2[s2.Length - 1] == s3[s3.Length - 1])){
            if((s1.Length > 0) &&(s1[s1.Length - 1] == s3[s3.Length - 1])){
                return InterleaveInt(s1.Substring(0, s1.Length - 1), s2, s3.Substring(0, s3.Length - 1)) || InterleaveInt(s1, s2.Substring(0, s2.Length - 1), s3.Substring(0, s3.Length - 1));
            }
            return InterleaveInt(s1, s2.Substring(0, s2.Length - 1), s3.Substring(0, s3.Length - 1));
        }
        if((s1.Length > 0) && s1[s1.Length - 1] == s3[s3.Length - 1]){
            return InterleaveInt(s1.Substring(0, s1.Length - 1), s2, s3.Substring(0, s3.Length - 1));
        }
        return false;
    }
}
