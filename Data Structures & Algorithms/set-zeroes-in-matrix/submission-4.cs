public class Solution {
    public void SetZeroes(int[][] matrix) {
        bool needToUpdateColumn0 = false;
        for(int i = 0; i < matrix.Length; i++){
            if(matrix[i][0] == 0) needToUpdateColumn0 = true;
            for(int j = 1; j < matrix[0].Length; j++){
                if(matrix[i][j] == 0){
                    matrix[i][0] = 0;
                    matrix[0][j] = 0;
                }
            }
        }

        for(int i = 1; i < matrix.Length; i++){
            if(matrix[i][0] == 0){
                int j = 1;
                while(j < matrix[0].Length){
                    matrix[i][j] = 0;
                    j++;
                }
            }
        }
        for(int j = 1; j < matrix[0].Length; j++){
            if(matrix[0][j] == 0){
                int i = 0;
                while(i < matrix.Length){
                    matrix[i][j] = 0;
                    i++;
                }
            }
        }
        if(matrix[0][0] == 0){
            int j = 1;
            while(j < matrix[0].Length){
                matrix[0][j] = 0;
                j++;
            }
        }
        if(needToUpdateColumn0){
            int i = 0;
            while(i < matrix.Length){
                matrix[i][0] = 0;
                i++;
            }
        }
        return;
    }

}