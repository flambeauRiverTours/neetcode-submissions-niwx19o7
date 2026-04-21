public class Solution {
    public void Rotate(int[][] matrix) {
        int n = matrix.Length;
        for(int offset = 0; offset < n / 2; offset++){
            int first = offset;
            int last = n - 1 - offset;
            for(int i = first; i < last; i++){
                int offset_i = i - first;
                int top = matrix[first][i];
                // left -> top
                matrix[first][i] = matrix[last - offset_i][first];
                // bottom -> left
                matrix[last - offset_i][first] = matrix[last][last - offset_i];
                // right -> bottom
                matrix[last][last - offset_i] = matrix[i][last];
                // top -> right
                matrix[i][last] = top;
            }
        }
    }
}