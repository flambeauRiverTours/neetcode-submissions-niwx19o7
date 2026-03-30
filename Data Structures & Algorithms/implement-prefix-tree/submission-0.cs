public class PrefixTree {
    TrieNode root;
    public PrefixTree() {
        root = new TrieNode();
    }
    
    public void Insert(string word) {
        TrieNode current = root;
        foreach(char letter in word.ToCharArray()){
            if(!current.children.ContainsKey(letter)){
                current.children[letter] = new TrieNode();
            }
            current = current.children[letter];
        }
        current.isWord = true;
    }
    
    public bool Search(string word) {
        TrieNode current = root;
        foreach(char letter in word.ToCharArray()){
            if(!current.children.ContainsKey(letter)){
                return false;
            }
            current = current.children[letter];
        }
        return current.isWord;
    }
    
    public bool StartsWith(string prefix) {
        TrieNode current = root;
        foreach(char letter in prefix.ToCharArray()){
            if(!current.children.ContainsKey(letter)){
                return false;
            }
            current = current.children[letter];
        }
        return true;
    }
}

public class TrieNode(){
    public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
    public bool isWord;
}
