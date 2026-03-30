public class Solution {
    public int SwimInWater(int[][] grid) {

        PriorityQueue<(int x, int y, int time), int> pq = new PriorityQueue<(int x, int y, int time), int>();
        pq.Enqueue((0, 0, grid[0][0]), grid[0][0]);
        HashSet<(int x, int y)> visitedSquares = new HashSet<(int x, int y)>();
        while(pq.Count > 0){
            (int x, int y, int time) nextSquare = pq.Dequeue();
            if((nextSquare.x == (grid.Length - 1)) && (nextSquare.y == (grid.Length - 1))){
                return nextSquare.time;
            }
            if(!visitedSquares.Contains((nextSquare.x, nextSquare.y))){
                visitedSquares.Add((nextSquare.x, nextSquare.y));
                foreach((int x, int y) point in GetPotentialNextSquares(nextSquare.x, nextSquare.y, grid.Length)){
                    int timeToSquare = Math.Max(nextSquare.time, grid[point.x][point.y]);
                    pq.Enqueue((point.x, point.y, timeToSquare), timeToSquare);
                }
            }
        }

        throw new Exception("No path found??");
    }

    private List<(int x, int y)> GetPotentialNextSquares(int x, int y, int gridSize){
        List<(int x, int y)> result = new List<(int x, int y)>();
        result.Add((x + 1, y));
        result.Add((x - 1, y));
        result.Add((x, y + 1));
        result.Add((x, y - 1));
        return result.Where(point => ((point.x >= 0) && (point.y >=0) && (point.x < gridSize) && (point.y < gridSize))).ToList();
    }
}