public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        List<int[]> intervalsList = new List<int[]>();
        int newIntervalStart = newInterval[0];
        int newIntervalEnd = newInterval[1];
        int intervalIndex = -1;
        for(int i = 0; i < intervals.Length; i++){
            int currentStart = intervals[i][0];
            int currentEnd = intervals[i][1];
            if(((newIntervalStart >= currentStart) && (newIntervalStart <= currentEnd)) ||
            ((newIntervalEnd >= currentStart) && (newIntervalEnd <= currentEnd)) ||
            ((currentStart >= newIntervalStart) && (currentEnd <= newIntervalEnd))){
                newIntervalStart = Math.Min(newIntervalStart, currentStart);
                newIntervalEnd = Math.Max(newIntervalEnd, currentEnd);
                if(intervalIndex == -1){
                    intervalsList.Add(new int[]{newIntervalStart, newIntervalEnd});
                    intervalIndex = intervalsList.Count - 1;
                }
                else{
                    intervalsList[intervalIndex][0] = newIntervalStart;
                    intervalsList[intervalIndex][1] = newIntervalEnd;
                }
            }
            else{
                intervalsList.Add(intervals[i]);
            }
            
        }
        if(intervalIndex == -1){
            intervalsList.Add(newInterval);
            ArrComparer comp = new ArrComparer();
            intervalsList.Sort(comp);
        }
        return intervalsList.ToArray();
    }


}
public class ArrComparer: IComparer<int[]>
{
    public int Compare(int[] a, int[] b){
        return a[0].CompareTo(b[0]);
    }
}
