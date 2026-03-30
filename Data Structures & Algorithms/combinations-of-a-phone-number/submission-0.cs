public class Solution {
    public List<string> LetterCombinations(string digits) {
        List<string> result = new List<string>();
        BackTrack(0, digits, "", result);
        return result;
    }

    private void BackTrack(int index, string digits, string currString, List<string> result){
        if(currString.Length == digits.Length){
            if(currString.Length != 0){
                result.Add(currString);
            }
            return;
        }
        foreach(char letter in DigitToLetter(digits[index])){
            currString = currString + letter;
            BackTrack(index + 1, digits, currString, result);
            currString = currString.Substring(0, currString.Length - 1);
        }
    }

    private List<char> DigitToLetter(char digit){
        switch(digit){
            case '2':
                return new List<char>() {'a', 'b', 'c'};
            case '3':
                return new List<char>() {'d', 'e', 'f'};
            case '4':
                return new List<char>() {'g', 'h', 'i'};
            case '5':
                return new List<char>() {'j', 'k', 'l'};
            case '6':
                return new List<char>() {'m', 'n', 'o'};
            case '7':
                return new List<char>() {'p', 'q', 'r', 's'};
            case '8':
                return new List<char>() {'t', 'u', 'v'};
            case '9':
                return new List<char>() {'w', 'x', 'y', 'z'};
            default:
                throw new Exception("Unhandled char passed: " + digit);
        }
    }
}
