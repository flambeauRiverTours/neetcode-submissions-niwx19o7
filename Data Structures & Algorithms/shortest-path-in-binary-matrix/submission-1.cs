public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        HashSet<(int row, int col)> visited = new HashSet<(int row, int col)>();
        Queue<(int row, int col)> queue = new Queue<(int row, int col)>();
        int length = 1;
        AddToPathAndVisitedIfValid(grid, (0, 0), visited, queue);
        int[] rowAndColDifferences = [-1, 0, 1];
        while(queue.Count > 0){
            int dequeuesToPerform = queue.Count;
            for(int i = 0; i < dequeuesToPerform; i++){
                (int row, int col) pos = queue.Dequeue();
                if(IsBottomRight(grid, pos)){
                    return length;
                }
                foreach(int rowDiff in rowAndColDifferences){
                    foreach(int colDiff in rowAndColDifferences){
                        AddToPathAndVisitedIfValid(grid, (pos.row + rowDiff, pos.col + colDiff), visited, queue);
                    }
                }
            }
            length++;
        }
        return -1;
    }

    private bool IsOutOfBounds(int[][] grid, (int row, int col) pos){
        return ((pos.row < 0) || (pos.col < 0) || (pos.row >= grid.Length) || (pos.col >= grid[0].Length));
    }

    private bool IsBottomRight(int[][] grid, (int row, int col) pos){
        return (pos.row == (grid.Length - 1)) && (pos.col == (grid[0].Length - 1));
    }

    private bool IsValidToAddToPath(int[][] grid, (int row, int col) pos, HashSet<(int row, int col)> visited){
        return ((!IsOutOfBounds(grid, pos)) && (grid[pos.row][pos.col] == 0) && (!visited.Contains(pos)));
    }

    private void AddToPathAndVisitedIfValid(int[][] grid, (int row, int col) pos, HashSet<(int row, int col)> visited, Queue<(int row, int col)> queue){
        if(IsValidToAddToPath(grid, pos, visited)){
            queue.Enqueue(pos);
            visited.Add(pos);
        }
    }
}