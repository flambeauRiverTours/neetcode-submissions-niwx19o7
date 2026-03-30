public class Solution {
    public int OrangesRotting(int[][] grid) {
        return BFS(grid);
    }

    private int CountFreshOranges(int[][] grid){
        int freshOranges = 0;
        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){
                if(grid[i][j] == 1){
                    freshOranges++;
                }
            }
        }
        return freshOranges;
    }

    private List<(int row, int col)> GetRottenOrangePositions(int[][] grid){
        List<(int row, int col)> rottenOrangePositionList = new List<(int row, int col)>();
        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){
                if(grid[i][j] == 2){
                    rottenOrangePositionList.Add((i, j));
                }
            }
        }
        return rottenOrangePositionList;
    }

    public int BFS(int[][] grid){
        HashSet<(int row, int col)> visited = new HashSet<(int row, int col)>();
        int length = 0;
        Queue<(int row, int col)> queue = new Queue<(int row, int col)>();
        foreach((int row, int col) pos in GetRottenOrangePositions(grid)){
            queue.Enqueue(pos);
            visited.Add(pos);
        }
        int freshOrangeCount = CountFreshOranges(grid);
        if(freshOrangeCount == 0) {return 0;}
        while(queue.Count > 0){
            int dequeuesToPerform = queue.Count;
            int cachedFreshOrange  = freshOrangeCount;
            for(int i = 0; i < dequeuesToPerform; i++){
                (int row, int col) pos = queue.Dequeue();

                
                if(IsValidToAddToPath(grid, (pos.row + 1, pos.col), visited)){
                    queue.Enqueue((pos.row + 1, pos.col));
                    visited.Add((pos.row + 1, pos.col));
                    freshOrangeCount--;
                }
                if(IsValidToAddToPath(grid, (pos.row - 1, pos.col), visited)){
                    freshOrangeCount--;
                    queue.Enqueue((pos.row - 1, pos.col));
                    visited.Add((pos.row - 1, pos.col));
                }
                if(IsValidToAddToPath(grid, (pos.row, pos.col + 1), visited)){
                    freshOrangeCount--;
                    queue.Enqueue((pos.row, pos.col + 1));
                    visited.Add((pos.row, pos.col + 1));
                }
                if(IsValidToAddToPath(grid, (pos.row, pos.col - 1), visited)){
                    freshOrangeCount--;
                    queue.Enqueue((pos.row, pos.col - 1));
                    visited.Add((pos.row, pos.col - 1));
                }

            }
            
            if(cachedFreshOrange != freshOrangeCount) {length++;}
            if(freshOrangeCount == 0) {return length;}
        }
        if(freshOrangeCount > 0) {return -1;}
        return length;
    }
    private bool IsOutOfBounds(int[][] grid, (int row, int col) pos){
        return ((pos.row < 0) || (pos.col < 0) || (pos.row >= grid.Length) || (pos.col >= grid[0].Length));
    }

    private bool IsValidToAddToPath(int[][] grid, (int row, int col) pos, HashSet<(int row, int col)> visited){
        return (!IsOutOfBounds(grid, pos) && (grid[pos.row][pos.col] == 1) && (!visited.Contains(pos)));
    }
}
