public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        if (!wordList.Contains(endWord)) { return 0; }
        if (beginWord == endWord) { return 1; }
        HashSet<string> uniqueWords = new HashSet<string>(wordList);
        uniqueWords.Add(beginWord);
        Dictionary<string, Word> dict = new Dictionary<string, Word>();
        foreach (string word in uniqueWords) {
            dict[word] = new Word(word);
        }
        foreach (string word in uniqueWords) {
            foreach (string otherWord in uniqueWords) {
                if (word != otherWord) {
                    if (IsOneDifference(word, otherWord)) {
                        dict[word].neighbors.Add(dict[otherWord]);
                    }
                }
            }
        }

        Queue<Word> queue = new Queue<Word>();
        queue.Enqueue(dict[beginWord]);
        HashSet<Word> visited = new HashSet<Word> { dict[beginWord] };
        int stepCount = 1;
        while (queue.Count > 0) {
            int numToPop = queue.Count;
            while (numToPop > 0) {
                numToPop--;
                Word currentWord = queue.Dequeue();
                if (currentWord.word == endWord) { return stepCount; }
                foreach (Word neighbor in currentWord.neighbors) {
                    if (!visited.Contains(neighbor)) {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
            stepCount++;
        }
        return 0;
    }

    private bool IsOneDifference(string word1, string word2) {
        int diffCount = 0;
        for (int i = 0; i < word1.Length; i++) {
            if (word1[i] != word2[i]) {
                diffCount++;
            }
        }
        return diffCount == 1;
    }
}

public class Word {
    public Word(string _word) {
        word = _word;
        neighbors = new List<Word>();
    }
    public string word;
    public List<Word> neighbors;
}