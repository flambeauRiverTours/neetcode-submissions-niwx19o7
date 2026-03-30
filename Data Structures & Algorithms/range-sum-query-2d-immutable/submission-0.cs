public class NumMatrix {

    public NumMatrix(int[][] matrix) {
        prefSum = new int[matrix.Length][];
        for(int i = 0; i < matrix.Length; i++){
            prefSum[i] = new int[matrix[i].Length];
            for(int j = 0; j < prefSum[i].Length; j++){
                if(i == 0){
                    if(j == 0){
                        prefSum[i][j] = matrix[i][j];
                    }
                    else{
                        prefSum[i][j] = matrix[i][j] + prefSum[i][j - 1];
                    }
                }
                else if (j == 0){
                    prefSum[i][j] = matrix[i][j] + prefSum[i - 1][j];
                }
                else{
                    prefSum[i][j] = matrix[i][j] + prefSum[i - 1][j] + prefSum[i][j - 1] - prefSum[i - 1][j - 1];
                }
            }
        }
    }
    int[][] prefSum;
    public int SumRegion(int row1, int col1, int row2, int col2) {
        int res = prefSum[row2][col2];
        if (row1 > 0) res -= prefSum[row1 - 1][col2];
        if (col1 > 0) res -= prefSum[row2][col1 - 1];
        if (row1 > 0 && col1 > 0) res += prefSum[row1 - 1][col1 - 1];
        return res;
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */