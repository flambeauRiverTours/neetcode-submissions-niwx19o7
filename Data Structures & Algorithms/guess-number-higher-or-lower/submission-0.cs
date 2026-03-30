/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */

public class Solution : GuessGame {
    public int GuessNumber(int n) {
        return BinarySearch(1, n);
    }

    private int BinarySearch(int left, int right){
        if (right < left) {return -1;}
        int mid = left + ((right - left) / 2);
        int guessResult = guess(mid);
        if(guessResult == 0){
            return mid;
        }
        else if (guessResult == -1){
            return BinarySearch(left, mid - 1);
        }
        else {
            return BinarySearch(mid + 1, right);
        }
    }
}