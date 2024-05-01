using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int[] solution(string[] operations)
    {
        List<int> answer = new List<int>();

        SortedList<(int Data, int Index), int> heap = new SortedList<(int Data, int Index), int>();

        for (int i = 0; i < operations.Length; i++)
        {
            string currentOper = operations[i];

            if (currentOper.Equals("D -1") && heap.Count > 0)
            {
                heap.RemoveAt(0);
            }
            else if (currentOper.Equals("D 1") && heap.Count > 0)
            {
                heap.RemoveAt(heap.Count - 1);
            }
            else if (currentOper.Contains("I "))
            {
                int data = Convert.ToInt32(currentOper.Substring(2));
                heap.Add((data, i), i);
            }
        }

        if (heap.Count > 0)
        {
            answer.Add(heap.Last().Key.Data);
            answer.Add(heap.First().Key.Data);
        }
        else
        {
            answer.Add(0);
            answer.Add(0);
        }

        return answer.ToArray();
    }
}