public class WordDictionary {
    TrieNode root;
    public WordDictionary() {
        root = new TrieNode();
    }
    
    public void AddWord(string word) {
        TrieNode currentNode = root;
        foreach(char letter in word.ToCharArray()){
            if(!currentNode.kids.ContainsKey(letter)){
                currentNode.kids[letter] = new TrieNode();
            }
            currentNode = currentNode.kids[letter];
        }
        currentNode.isWord = true;
    }

    private bool RecurseSearch(TrieNode currentNode, string word){
        if(word == "") {return currentNode.isWord;}
        string newWord = word.Substring(1, word.Length - 1);
        if(word[0] == '.'){
            foreach(char key in currentNode.kids.Keys){
                if(RecurseSearch(currentNode.kids[key], newWord)){
                    return true;
                }
            }
            return false;
        }
        else{
            if(!currentNode.kids.ContainsKey(word[0])){ return false;}
            return RecurseSearch(currentNode.kids[word[0]], newWord);
        }
        
    }
    
    public bool Search(string word) {
        TrieNode currentNode = root;
        return RecurseSearch(currentNode, word);
    }
}

public class TrieNode{
    public Dictionary<char, TrieNode> kids = new Dictionary<char, TrieNode>();
    public bool isWord;
}
