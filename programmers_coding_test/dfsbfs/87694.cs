using System;
using System.Collections.Generic;

public class Solution {
    public Point[,] Points;

    public void VisitedInRectangles((int, int) a, (int, int) b)
    {
        for (int i = a.Item1 + 1; i < b.Item1; i++)
        {
            for (int j = a.Item2 + 1; j < b.Item2; j++)
            {
                Points[i, j].IsVisited = true;
            }
        }
    }
    
    public void ConnectingTwoPoints((int, int) a, (int, int) b)
    {
        var startX = a.Item1;
        var endX = b.Item1;
        var startY = a.Item2;
        var endY = b.Item2;

        while (startX < endX)
        {
            var startPoint1 = Points[startX, startY];
            var nextPoint1 = Points[startX + 1, startY];
            
            var startPoint2 = Points[startX, endY];
            var nextPoint2 = Points[startX + 1, endY];
            
            // startY 기준으로 점 2개를 연결
            startPoint1.ConnectPoint(nextPoint1);
            nextPoint1.ConnectPoint(startPoint1);
            
            // endY 기준으로 점 2개를 연결
            startPoint2.ConnectPoint(nextPoint2);
            nextPoint2.ConnectPoint(startPoint2);
            
            startX++;
        }
        
        startX = a.Item1;
        endX = b.Item1;
        startY = a.Item2;
        endY = b.Item2;
        
        while (startY < endY)
        {
            var startPoint1 = Points[startX, startY];
            var nextPoint1 = Points[startX, startY + 1];
            
            var startPoint2 = Points[endX, startY];
            var nextPoint2 = Points[endX, startY + 1];
            
            // startX 기준으로 점 2개를 연결
            startPoint1.ConnectPoint(nextPoint1);
            nextPoint1.ConnectPoint(startPoint1);
            
            // endX 기준으로 점 2개를 연결
            startPoint2.ConnectPoint(nextPoint2);
            nextPoint2.ConnectPoint(startPoint2);
            
            startY++;
        }
    }

    public class Point
    {
        public int x;
        public int y;
        public int Count = 0;
        public bool IsVisited = false;
        public List<Point> lines = new List<Point>();

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void ConnectPoint(Point b)
        {
            lines.Add(b);
        }
    }

    public int CalcAnswer(int px, int py, int ix, int iy)
    {
        var q = new Queue<Point>();
        var player = Points[px, py];
        player.IsVisited = true;
        q.Enqueue(Points[px, py]);

        while (0 < q.Count)
        {
            var point = q.Dequeue();
            
            for (var i = 0; i < point.lines.Count; i++)
            {
                var nextPoint = point.lines[i];
                
                if (nextPoint.IsVisited == false)
                {
                    nextPoint.IsVisited = true;
                    nextPoint.Count = point.Count + 1;
                    q.Enqueue(nextPoint);
                }
            }
        }

        return Points[ix, iy].Count / 2;
    }

    public int solution(int[,] rectangle, int characterX, int characterY, int itemX, int itemY)
    {
        int pointX = 200;
        int pointY = 200;
        Points = new Point[pointX, pointY];

        for (int i = 0; i < pointX; i++)
        {
            for (int j = 0; j < pointY; j++)
            {
                Points[i, j] = new Point(i, j);
            }
        }
        
        for(int i = 0; i < rectangle.GetLength(0); i++)
        {
            VisitedInRectangles((rectangle[i, 0] * 2, rectangle[i, 1] * 2), (rectangle[i, 2] * 2, rectangle[i, 3] * 2));
            ConnectingTwoPoints((rectangle[i,0] * 2, rectangle[i,1] *2 ), (rectangle[i,2] * 2, rectangle[i,3] * 2));
        }
        
        return CalcAnswer(characterX * 2, characterY * 2, itemX * 2, itemY * 2);
    }
}