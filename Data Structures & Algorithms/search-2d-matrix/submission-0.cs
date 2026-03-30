public class Solution {
    private int numberOfArrays;
    private int individualArrayLength;
    public bool SearchMatrix(int[][] matrix, int target) {
        numberOfArrays = matrix.Length;
        individualArrayLength = matrix[0].Length;
        return MatrixBinarySearch(matrix, target, 0, (numberOfArrays * individualArrayLength)-1);
    }

    private bool MatrixBinarySearch(int[][] matrix, int target, int left, int right){
        if(left > right ) {return false;}

        int mid = left + ((right - left) / 2);
        int midArrayNumber = mid / individualArrayLength;
        int midArrayIndex = mid % individualArrayLength;
        if(matrix[midArrayNumber][midArrayIndex] == target){
            return true;
        }
        else if (matrix[midArrayNumber][midArrayIndex] < target){
            return MatrixBinarySearch(matrix, target, mid + 1, right);
        }
        else{
            return MatrixBinarySearch(matrix, target, left, mid - 1);
        }
    }
}

