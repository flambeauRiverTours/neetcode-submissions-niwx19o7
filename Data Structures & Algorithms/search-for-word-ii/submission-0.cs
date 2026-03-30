public class Solution {
    public List<string> FindWords(char[][] board, string[] words) {
        charPoses = new Dictionary<char, List<(int x, int y)>>();
        LetterLocations(board);
        List<string> resultString = new List<string>();
        foreach(string word in words){
            if(HandleWordSearch(board, word)){
                resultString.Add(word);
            }
        }
        return resultString;
    }
    Dictionary<char, List<(int x, int y)>> charPoses;

    private bool HandleWordSearch(char[][] board, string word){
        if(!charPoses.ContainsKey(word[0])) {return false;}
        foreach((int x, int y) start in charPoses[word[0]]){
            Stack<(int x, int y)> slotsUsed = new Stack<(int x, int y)>();
            if(WordSearch(board, word, start, slotsUsed)){
                while(slotsUsed.Count > 0){
                    (int x, int y) killSpot = slotsUsed.Pop();
                    //board[killSpot.x][killSpot.y] = '0';
                }
                return true;
            }
        }
        return false;
    }

    private bool WordSearch(char[][] board, string word, (int x, int y) currentSpace, Stack<(int x, int y)> currentSpacesUsed){
        if(!IsSpaceValid(board, currentSpace)){return false;}
        if(currentSpacesUsed.Contains(currentSpace)) {return false;}
        if(board[currentSpace.x][currentSpace.y] != word[0]) { return false; }
        currentSpacesUsed.Push(currentSpace);
        word = word.Substring(1, word.Length - 1);
        if (word == "") {return true;}
        if(WordSearch(board, word, (currentSpace.x + 1, currentSpace.y), currentSpacesUsed)){
            return true;
        }
        if(WordSearch(board, word, (currentSpace.x - 1, currentSpace.y), currentSpacesUsed)){
            return true;
        }
        if(WordSearch(board, word, (currentSpace.x, currentSpace.y - 1), currentSpacesUsed)){
            return true;
        }
        if(WordSearch(board, word, (currentSpace.x, currentSpace.y + 1), currentSpacesUsed)){
            return true;
        }
        currentSpacesUsed.Pop();
        return false;
    }


    private void LetterLocations(char[][] board){
        for(int i = 0; i < board.Length; i++){
            for(int j = 0; j < board[0].Length; j++){
                if(!charPoses.ContainsKey(board[i][j])){
                    charPoses[board[i][j]] = new List<(int x, int y)>();
                }
                charPoses[board[i][j]].Add((i, j));
            }
        }
    }

    private bool IsSpaceValid(char[][] board, (int x, int y) space){
        if((space.x < 0) || (space.x >= board.Length)) {return false;}
        if((space.y < 0) || (space.y >= board[0].Length)) {return false;}
        return board[space.x][space.y] != '0';
    }
}
