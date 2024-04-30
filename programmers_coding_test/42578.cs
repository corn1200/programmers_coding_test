using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string[,] clothes) {
        // 의상 종류별 가짓수를 저장하는 딕셔너리
        Dictionary<string, int> clothesCnt = new Dictionary<string, int>();

        // 의상 순회
        for (int i = 0; i < clothes.GetLength(0); i++)
        {
            // 의상의 종류 
            string type = clothes[i, 1];
            // 의상이 딕셔너리에 있을 경우
            if (clothesCnt.ContainsKey(type))
            {
                // 의상 종류의 가짓수를 증가
                clothesCnt[type]++;
            }
            else
            {
                // 의상 종류를 추가하고 1로 초기화
                clothesCnt[type] = 1;
            }
        }
        
        int answer = 1;

        // 의상 종류별 가짓수 순회
        foreach (var variable in clothesCnt.Values)
        {
            // 의상 종류별 가짓수에 입지 않았을 경우를 더해 곱한다
            answer *= (variable + 1);
        }

        // 아무것도 입지 않았을 경우 제외
        answer--;
        
        return answer;
    }
}