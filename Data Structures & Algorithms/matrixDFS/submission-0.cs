public class Solution {
    public int CountPaths(int[][] grid) {
        return RecursiveHashMap(grid, (0, 0), new HashSet<(int row, int col)>());
    }

    private int RecursiveHashMap(int[][] grid, (int row, int col) position, HashSet<(int row, int col)> visited){
        int numberOfRows = grid.Length;
        int numberOfColumns = grid[0].Length;
        if((position.row == -1) || (position.col == -1) || (position.row == numberOfRows) || (position.col == numberOfColumns) ||
            (grid[position.row][position.col] == 1) || (visited.Contains(position))){
                return 0;
        }
        if((position.row == (numberOfRows - 1)) && (position.col == (numberOfColumns - 1))){
            return 1;
        }
        int count = 0;
        visited.Add(position);
        count += RecursiveHashMap(grid, (position.row + 1, position.col), visited);
        count += RecursiveHashMap(grid, (position.row - 1, position.col), visited);
        count += RecursiveHashMap(grid, (position.row, position.col + 1), visited);
        count += RecursiveHashMap(grid, (position.row, position.col - 1), visited);
        visited.Remove(position);
        return count;
    }
}
