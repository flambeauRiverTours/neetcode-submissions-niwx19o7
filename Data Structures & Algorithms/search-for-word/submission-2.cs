public class Solution {
    public bool Exist(char[][] board, string word) {
        for(int i = 0; i < board.Length; i++){
            for(int j = 0; j < board[0].Length; j++){
                if(DFS(board, word, (i, j), new HashSet<(int x, int y)>())){
                    return true;
                }
            }
        }
        return false;
    }

    public bool DFS(char[][] board, string word, (int x, int y) startingPoint, HashSet<(int x, int y)> usedPoints){
        if(!IsPointValid(board, usedPoints, startingPoint, word[0])) {return false;}
        string newWord = word.Substring(1, word.Length - 1);
        if(newWord.Length == 0) {return true;}
        usedPoints.Add(startingPoint);
        foreach((int x, int y) nextPoint in GetSurroundingCells(startingPoint)){
            if(DFS(board, newWord, nextPoint, usedPoints)){
                return true;
            }
        }
        usedPoints.Remove(startingPoint);
        return false;
    }

    public List<(int x, int y)> GetSurroundingCells((int x, int y) point){
        List<(int x, int y)> surroundingCells = new List<(int x, int y)>();
        surroundingCells.Add((point.x + 1, point.y));
        surroundingCells.Add((point.x - 1, point.y));
        surroundingCells.Add((point.x, point.y + 1));
        surroundingCells.Add((point.x, point.y - 1));
        return surroundingCells;
    }

    public bool IsPointValid(char[][] board, HashSet<(int x, int y)> usedPoints, (int x, int y) point, char targetChar){
        
        if(point.x < 0 || point.y < 0) {return false;}
        if(point.x >= board.Length || point.y >= board[0].Length) {return false; }
        if(usedPoints.Contains(point)) {return false;}
        return (board[point.x][point.y] == targetChar);
    }
}