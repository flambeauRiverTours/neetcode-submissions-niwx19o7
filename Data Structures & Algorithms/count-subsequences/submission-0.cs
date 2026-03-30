public class Solution {
    public int NumDistinct(string s, string t) {
        int[,] dp = new int[t.Length + 1, s.Length  + 1];
        for(int i = 1; i <= t.Length; i++){

            for(int j = 0; j <= s.Length; j++){
                dp[0,j]= 1;
                if(j !=0){
                    dp[i, j] = dp[i, j-1];
                    if(s[j - 1] == t[i - 1]){
                        dp[i,j] += dp[i-1, j-1];
                    }
                }
            }
        }
        return dp[t.Length, s.Length];
    }
}
