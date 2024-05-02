using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(int[] array, int[,] commands) {
        List<int> answer = new List<int>();

        for (int i = 0; i < commands.GetLength(0); i++)
        {
            int iCom = commands[i, 0];
            int jCom = commands[i, 1];
            int kCom = commands[i, 2];

            List<int> copy = array.Skip(iCom - 1).Take(jCom - iCom + 1).ToList();
            copy.Sort();
            answer.Add(copy[kCom - 1]);
        }
        
        return answer.ToArray();
    }
}