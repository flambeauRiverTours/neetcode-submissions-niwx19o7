public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        int colLength = text1.Length;
        int rowLength = text2.Length;
        int[] prevRow = new int[rowLength];

        for(int i = (colLength - 1); i >= 0; i--){
            int[] currRow = new int[rowLength];
            for(int j = (rowLength - 1); j >= 0; j--){
                bool shouldAddVal = (text1[i] == text2[j]);
                if(shouldAddVal){
                    if((i == (colLength - 1)) || j == (rowLength - 1)){
                        currRow[j] = 1;
                    }
                    else{
                        currRow[j] = 1 + prevRow[j + 1];
                    }
                }
                else { 
                    int belowVal = 0;
                    if(i != (colLength - 1)){
                        belowVal = prevRow[j];
                    }
                    int rightVal = 0;
                    if(j != (rowLength - 1)){
                        rightVal = currRow[j + 1];
                    }
                    currRow[j] += Math.Max(belowVal, rightVal);
                }
            }
            prevRow = currRow;
        }
        return prevRow[0];
    }
}
