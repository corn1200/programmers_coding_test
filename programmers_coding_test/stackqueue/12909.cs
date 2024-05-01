using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public bool solution(string s) {
        bool answer = true;
        Stack<char> bracket = new Stack<char>();
        
        foreach (var c in s.ToArray())
        {
            switch (c)
            {
                case '(':
                    bracket.Push(c);
                    break;
                case ')':
                    if (bracket.Count > 0)
                    {
                        bracket.Pop();
                    }
                    else
                    {
                        answer = false;
                        return answer;
                    }
                    break;
            }            
        }

        answer = bracket.Count == 0;
        return answer;
    }
}