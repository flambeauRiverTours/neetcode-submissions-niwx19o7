public class Solution {
    public int NumIslands(char[][] grid) {
        visitedHashmap = new HashSet<(int row, int col)>();
        int islandCount = 0;
        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){
                if(!visitedHashmap.Contains((i, j)) && (grid[i][j] == '1')){
                    islandCount++;
                    RecursiveIslandCounter(grid, (i, j));
                }
            }
        }

        return islandCount;
    }
    HashSet<(int row, int col)> visitedHashmap;

    private void RecursiveIslandCounter(char[][] grid, (int row, int col) position){
        if(IsPositionOutOfBounds(grid, position) || visitedHashmap.Contains(position) || grid[position.row][position.col] == '0'){
            return;
        }
        visitedHashmap.Add(position);
        RecursiveIslandCounter(grid, (position.row + 1, position.col));
        RecursiveIslandCounter(grid, (position.row - 1, position.col));
        RecursiveIslandCounter(grid, (position.row, position.col + 1));
        RecursiveIslandCounter(grid, (position.row, position.col - 1));
    }

    private bool IsPositionOutOfBounds(char[][] grid, (int row, int col) position){
        return ((position.row == -1) || (position.col == -1) || (position.row == grid.Length) || (position.col == grid[0].Length));
    }
}
