/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution {
    public bool CanAttendMeetings(List<Interval> intervals) {
        intervals.Sort(delegate(Interval x, Interval y ){
            return x.start.CompareTo(y.start);
        });
        for(int i = 0; i < (intervals.Count - 1); i++){
            if(intervals[i].end > intervals[i + 1].start){
                return false;
            }
        }
        return true;
    }
}
