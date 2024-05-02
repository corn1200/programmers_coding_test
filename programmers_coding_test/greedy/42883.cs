using System;
using System.Collections.Generic;

public class Solution {
    public string solution(string number, int k) {
        // 문자를 저장할 스택
        Stack<char> stack = new Stack<char>();
        // 제거할 문자 수를 추적
        int toRemove = k;

        // 문자 순회
        foreach (char digit in number)
        {
            // 스택이 비어 있지 않고, 제거할 숫자가 남아 있으며,
            // 스택의 마지막 요소가 현재 숫자보다 작다면 스택에서 제거
            while (stack.Count > 0 && toRemove > 0 && stack.Peek() < digit)
            {
                stack.Pop();
                toRemove--;
            }
            // 현재 숫자를 스택에 추가
            stack.Push(digit);
        }

        // 제거할 수 있는 기회가 남아 있으면 스택에서 그만큼 더 제거
        while (toRemove > 0)
        {
            stack.Pop();
            toRemove--;
        }

        // 스택에서 결과 문자열 생성
        // 최종 문자를 역순으로 저장할 스택
        var resultStack = new Stack<char>();
        while (stack.Count > 0)
            resultStack.Push(stack.Pop());
        
        // 결과 문자 배열
        var result = new char[resultStack.Count];
        int index = 0;
        while (resultStack.Count > 0)
            result[index++] = resultStack.Pop();
        
        // 결과 문자 배열을 문자열로 변환하여 반환
        return new string(result);
    }
}