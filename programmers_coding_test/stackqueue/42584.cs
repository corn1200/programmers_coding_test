using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] prices) {
        List<int> answer = new List<int>();

        for (int i = 0; i < prices.Length; i++)
        {
            int time = -1;
            for (int j = i; j < prices.Length; j++)
            {
                time++;
                if (prices[i] > prices[j])
                {
                    break;
                }
            }
            answer.Add(time);
        }
        
        return answer.ToArray();
    }
}