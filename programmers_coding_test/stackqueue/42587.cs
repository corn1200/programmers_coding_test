using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    class Process
    {
        public int location;
        public int priority;

        public Process(int location, int priority)
        {
            this.location = location;
            this.priority = priority;
        }
    }
    
    public int solution(int[] priorities, int location) {
        int answer = 0;
        Queue<Process> queue = new Queue<Process>();

        for (int i = 0; i < priorities.Length; i++)
        {
            queue.Enqueue(new Process(i, priorities[i]));
        }

        while (queue.Count > 0)
        {
            Process current = queue.Dequeue();
            var query = queue.Count(e => e.priority > current.priority);
            if (query > 0)
            {
                queue.Enqueue(current);
            }
            else
            {
                answer++;
                if (current.location == location)
                {
                    return answer;
                }
            }
        }
        
        return answer;
    }
}