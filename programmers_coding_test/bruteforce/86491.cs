using System;

public class Solution {
    public int solution(int[,] sizes) {
        int width = 0;
        int length = 0;

        for (int i = 0; i < sizes.GetLength(0); i++)
        {
            int currWidth = sizes[i, 0]; 
            int currLength = sizes[i, 1];
            if (currWidth > currLength)
            {
                int temp = currWidth;
                currWidth = currLength;
                currLength = temp;
            }
            width = width < currWidth ? currWidth : width;
            length = length < currLength ? currLength : length;
        }
        
        return width * length;
    }
}