public class Solution {
    public int UniquePaths(int m, int n) {
        int[] prevRow = new int[n];
        for(int i = 0; i < n; i++){
            prevRow[i] = 1;
        }
        for(int j = m - 2; j >= 0; j--){
            int[] currRow = new int[n];
            for(int i = n-1; i >= 0; i--){
                if(i < (n-1)){
                    currRow[i] = currRow[i+1] + prevRow[i];
                }
                else{
                    currRow[i] = prevRow[i];
                }
            }
            prevRow = currRow;
        }
        return prevRow[0];
    }
}
