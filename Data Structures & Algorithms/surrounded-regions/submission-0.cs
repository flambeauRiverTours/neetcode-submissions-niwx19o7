public class Solution {
    HashSet<(int x, int y)> unsurrounded;
    public void Solve(char[][] board) {
        unsurrounded = new HashSet<(int x, int y)>();
        for(int x = 0; x < board.Length; x++){
            for(int y = 0; y < board[0].Length; y++){
                if(board[x][y] == 'O' && !unsurrounded.Contains((x, y))){
                    HashSet<(int x, int y)> used = new HashSet<(int x, int y)>();
                    if(DFS(x, y, used, board)){
                        foreach((int x, int y) usedSquare in used){
                            board[usedSquare.x][usedSquare.y] = 'X';
                        }
                    }
                    else{
                        foreach((int x, int y) usedSquare in used){
                            unsurrounded.Add((usedSquare.x, usedSquare.y));
                        }
                    }
                }
            }
        }
    }

    private bool DFS(int x, int y, HashSet<(int x, int y)> used, char[][] board){
        if((x < 0) || (y < 0) || (x == board.Length) || (y == board[0].Length)) { return false;}
        if(board[x][y] == 'X') {return true;}
        if(used.Contains((x, y))) {return true;}
        if(unsurrounded.Contains((x, y))) {return false;}
        used.Add((x, y));
        return DFS(x + 1, y, used, board) && DFS(x - 1, y, used, board) 
            && DFS(x, y + 1, used, board) && DFS(x, y - 1, used, board);
        
    }
}