public class Solution {
    public int LongestIncreasingPath(int[][] matrix) {
        maxVals = new int[matrix.Length, matrix[0].Length];
        int max = 0;
        for(int x = 0;x < matrix.Length; x++){
            for(int y = 0; y < matrix[0].Length; y++){
                max = Math.Max(max, DFS(x, y, -1, matrix));
            }
        }
        return max;
    }

    int[,] maxVals;
    private int DFS(int x, int y, int barVal, int[][] matrix){
        if((x == -1) || (y == -1) || (x == matrix.Length) || (y == matrix[0].Length)) { return 0;}
        if(barVal >= matrix[x][y]) {return 0;}
        if(maxVals[x, y] != 0) {return maxVals[x, y];}
        int result = Math.Max(DFS(x + 1, y, matrix[x][y], matrix), DFS(x - 1, y, matrix[x][y], matrix));
        result = Math.Max(result, DFS(x, y + 1, matrix[x][y], matrix));
        result = Math.Max(result, DFS(x, y - 1, matrix[x][y], matrix));
        result++; // count this square;
        maxVals[x,y] = result;
        return result;
    }
}
