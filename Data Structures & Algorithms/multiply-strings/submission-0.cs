public class Solution {
    public string Multiply(string num1, string num2) {
        if (num1 == "0" || num2 == "0") return "0";
        int[] res = new int[num1.Length + num2.Length];
        for (int i = num1.Length - 1; i >= 0; i--) {
            for (int j = num2.Length - 1; j >= 0; j--) {
                int mult = CharToInt(num1[i]) * CharToInt(num2[j]);
                int sum = mult + res[i + j + 1];
                res[i + j + 1] = sum % 10;
                res[i + j] += sum / 10;
            }
        }
        StringBuilder sb = new StringBuilder();
        foreach (int p in res) if (!(sb.Length == 0 && p == 0)) sb.Append(p);
        return sb.ToString();
    }

    private int CharToInt(char character){
        switch(character){
            case '0':
                return 0;
            case '1':
                return 1;
            case '2':
                return 2;
            case '3':
                return 3;
            case '4':
                return 4;
            case '5':
                return 5;
            case '6':
                return 6;
            case '7':
                return 7;
            case '8':
                return 8;
            case '9':
                return 9;
            default:
                throw new Exception("Bad Char");
        }
    }
}