using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int[] citations) {
        int answer = 0;
        List<int> copy = new List<int>(citations);
        copy.Sort();

        for (int i = copy.Count; i >= 0 ; i--)
        {
            if (copy.Count(x => i <= x) >= i && copy.Count(x => i >= x) <= i)
            {
                return i;
            }
        }
        
        return answer;
    }
}