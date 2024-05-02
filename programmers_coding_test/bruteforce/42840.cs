using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int[] solution(int[] answers)
    {
        List<int> answer = new List<int>();
        int[] failer1 = { 1, 2, 3, 4, 5 };
        int[] failer2 = { 2, 1, 2, 3, 2, 4, 2, 5 };
        int[] failer3 = { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 };
        int index1 = 0, index2 = 0, index3 = 0;
        int answer1 = 0, answer2 = 0, answer3 = 0;

        foreach (var i in answers)
        {
            answer1 += i == failer1[index1] ? 1 : 0;
            answer2 += i == failer2[index2] ? 1 : 0;
            answer3 += i == failer3[index3] ? 1 : 0;

            index1 = index1 == failer1.Length - 1 ? 0 : index1 + 1;
            index2 = index2 == failer2.Length - 1 ? 0 : index2 + 1;
            index3 = index3 == failer3.Length - 1 ? 0 : index3 + 1;
        }

        int max = new[] {answer1, answer2, answer3 }.Max();
        if (answer1 == max)
        {
            answer.Add(1);
        }
        if (answer2 == max)
        {
            answer.Add(2);
        }
        if (answer3 == max)
        {
            answer.Add(3);
        }

        return answer.ToArray();
    }
}