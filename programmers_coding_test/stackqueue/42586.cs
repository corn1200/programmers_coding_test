using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] progresses, int[] speeds) {
        List<int> answer = new List<int>();
        Queue<double> queue = new Queue<double>();
        
        for (int i = 0; i < progresses.Length; i++)
        {
            queue.Enqueue(Math.Ceiling((double) (100 - progresses[i]) / (double) speeds[i]));
        }

        int currentDay = -1;
        int listIndex = -1;
        while (queue.Count > 0)
        {
            double queueResult = queue.Dequeue();
            if (currentDay < queueResult)
            {
                currentDay = (int)queueResult;
                answer.Add(1);
                listIndex++;
            }
            else
            {
                answer[listIndex]++;
            }
        }
        
        return answer.ToArray();
    }
}