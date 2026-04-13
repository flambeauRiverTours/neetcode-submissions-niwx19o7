public class Solution {
    HashSet<(int r, int c)> hashSet;
    public List<List<int>> PacificAtlantic(int[][] heights) {
        int ROWS = heights.Length;
        int COLS = heights[0].Length;
        bool[,] pac = new bool[ROWS, COLS];
        bool[,] atl = new bool[ROWS, COLS];

        for (int c = 0; c < COLS; c++) {
            DFS(0, c, pac, heights[0][c], heights);
            DFS(ROWS - 1, c, atl, heights[ROWS - 1][c], heights);
        }
        for (int r = 0; r < ROWS; r++) {
            DFS(r, 0, pac, heights[r][0], heights);
            DFS(r, COLS - 1, atl, heights[r][COLS - 1], heights);
        }

        List<List<int>> result = new List<List<int>>();
        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (pac[r, c] && atl[r, c]) {
                    result.Add(new List<int> { r, c });
                }
            }
        }
        return result;
    }

    private void DFS(int r, int c, bool[,] ocean, int prevHeight, int[][] heights) {
        if (r < 0 || c < 0 || r >= heights.Length || c >= heights[0].Length || 
            ocean[r, c] || heights[r][c] < prevHeight) {
            return;
        }
        ocean[r, c] = true;
        DFS(r + 1, c, ocean, heights[r][c], heights);
        DFS(r - 1, c, ocean, heights[r][c], heights);
        DFS(r, c + 1, ocean, heights[r][c], heights);
        DFS(r, c - 1, ocean, heights[r][c], heights);
    }
}