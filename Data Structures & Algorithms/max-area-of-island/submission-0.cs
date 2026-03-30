public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        int maxArea = 0;
        visitedHashSet = new HashSet<(int row, int col)>();
        for(int rowIndex = 0; rowIndex < grid.Length; rowIndex++){
            for(int colIndex = 0; colIndex < grid[0].Length; colIndex++){
                if((grid[rowIndex][colIndex] == 1) && !visitedHashSet.Contains((rowIndex, colIndex))){

                    int newIslandArea = RecursiveDFS(grid, (rowIndex, colIndex));
                    if(newIslandArea > maxArea){
                        maxArea = newIslandArea;
                    }
                }
            }
        }
        return maxArea;
    }
    HashSet<(int row, int col)> visitedHashSet;
    private int RecursiveDFS(int[][] grid, (int row, int col) pos){
        if(IsPositionOutOfBounds(grid, pos) || visitedHashSet.Contains(pos) || 
            (grid[pos.row][pos.col] == 0)){
            return 0;
        }
        int area = 1;
        visitedHashSet.Add(pos);
        area += RecursiveDFS(grid, (pos.row + 1, pos.col));
        area += RecursiveDFS(grid, (pos.row - 1, pos.col));
        area += RecursiveDFS(grid, (pos.row, pos.col + 1));
        area += RecursiveDFS(grid, (pos.row, pos.col - 1));
        return area;
    }

    private bool IsPositionOutOfBounds(int[][] grid, (int row, int col) pos){
        return ((pos.row == -1) || (pos.col == -1) || (pos.row == grid.Length) || (pos.col == grid[0].Length));
    }
}
