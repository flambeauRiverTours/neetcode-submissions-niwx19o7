public class Solution {
    public int ShortestPath(int[][] grid) {

        Queue<(int row, int col)> queue = new Queue<(int row, int col)>();
        HashSet<(int row, int col)> visited = new HashSet<(int row, int col)>();
        queue.Enqueue((0, 0));
        visited.Add((0, 0));
        int length = 0;
        while (queue.Count > 0){
            int popsForThisLevel = queue.Count;
            for(int i = 0; i < popsForThisLevel; i++){
                (int row, int col) pos = queue.Dequeue();
                if(IsBottomRight(grid, pos)){
                    return length;
                }
                EnqueueAndMarkVisitedIfValid(grid, (pos.row + 1, pos.col), queue, visited);
                EnqueueAndMarkVisitedIfValid(grid, (pos.row - 1, pos.col), queue, visited);
                EnqueueAndMarkVisitedIfValid(grid, (pos.row, pos.col + 1), queue, visited);
                EnqueueAndMarkVisitedIfValid(grid, (pos.row, pos.col - 1), queue, visited);
            }
            length++;
        }
        return -1;
    }

    private void EnqueueAndMarkVisitedIfValid(int[][] grid, (int row, int col) pos, Queue<(int row, int col)> queue, HashSet<(int row, int col)> visitedHashSet){
        if(!IsValid(grid, (pos.row, pos.col))){
            return;
        }
        if(visitedHashSet.Contains(pos)){
            return;
        }
        queue.Enqueue(pos);
        visitedHashSet.Add(pos);
    }

    private bool OutOfBounds(int[][] grid, (int row, int col) pos){
        return ((pos.row < 0) || (pos.col < 0) || (pos.row >= grid.Length) || (pos.col >= grid[0].Length));
    }

    private bool IsBottomRight(int[][] grid, (int row, int col) pos){
        return ((pos.row == (grid.Length - 1)) && (pos.col == (grid[0].Length - 1)));
    }

    private bool IsValid(int[][] grid, (int row, int col) pos){
        if(OutOfBounds(grid, pos)){return false;}
        return (grid[pos.row][pos.col] == 0);
    }

}
