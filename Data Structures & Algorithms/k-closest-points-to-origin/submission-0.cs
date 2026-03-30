public class Solution {
    private int numberOfPointsToHold = -1;
    private PriorityQueue<Point, double> pq = new PriorityQueue<Point, double>();
    public int[][] KClosest(int[][] points, int k) {
        numberOfPointsToHold = k;
        pq.Clear();
        foreach(int[] point in points){
            AddPoint(new Point(point[0], point[1]));
        }
        int[][] result = new int[k][];
        int index = 0;
        while(pq.Count > 0){
            Point currentPoint = pq.Dequeue();
            result[index] = new int[] { currentPoint.X, currentPoint.Y };
            index++;
        }
        return result;
    }

    private void AddPoint(Point newPoint){
        if(pq.Count < numberOfPointsToHold){
            AddPointToPQ(newPoint);
        }
        else if (newPoint.Distance < pq.Peek().Distance) {
            pq.Dequeue();
            AddPointToPQ(newPoint);
        }
    }

    private void AddPointToPQ(Point newPoint){
        pq.Enqueue(newPoint, -1 * newPoint.Distance);
    }
}

public class Point{
    public Point(int xInput, int yInput){
        X = xInput;
        Y = yInput;
        Distance = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
    }


    public int X {get;}
    public int Y {get;}
    public double Distance {get;}
}


