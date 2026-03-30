public class Solution {
    public List<int> SpiralOrder(int[][] matrix) {
        List<int> result = new List<int>();
        bool reachedEnd = false;
        (int x, int y) next = (0, 0);
        Direction currentDirection = Direction.Right;
        while(!reachedEnd){
            result.Add(matrix[next.x][next.y]);
            matrix[next.x][next.y] = -101;
            (int x, int y) maybeNext = GetNext(next, currentDirection);
            if(OutOfBounds(maybeNext, matrix)){
                currentDirection = (Direction)(((int)currentDirection + 1) % 4);
                (int x, int y) rotatedNext = GetNext(next, currentDirection);
                if(OutOfBounds(rotatedNext, matrix)){
                    reachedEnd = true;
                }
                else{
                    next = rotatedNext;
                }
            }
            else{
                next = maybeNext;
            }
        }
        return result;
    }

    private bool OutOfBounds((int x, int y) current, int[][] matrix){
        if(current.x < 0 || current.x >= matrix.Length) {return true;}
        if(current.y < 0 || current.y >= matrix[0].Length) {return true;}
        return matrix[current.x][current.y] == -101;
    }

    private (int x, int y) GetNext((int x, int y) current, Direction direction){
        switch (direction){
            case Direction.Right:
                return (current.x, current.y + 1);
            case Direction.Down:
                return (current.x + 1, current.y);
            case Direction.Left:
                return (current.x, current.y - 1);
            case Direction.Up:
                return (current.x - 1, current.y);
        }

        throw new Exception("Unrecognized direction. Z????");
    }
}
enum Direction{
    Right = 0,
    Down = 1,
    Left = 2,
    Up = 3,
}