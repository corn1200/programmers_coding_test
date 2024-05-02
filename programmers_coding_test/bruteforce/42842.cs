using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int brown, int yellow) {
        // 답안 리스트
        List<int> answer = new List<int>();

        // 노란색 카펫의 세로가 1인 경우부터 시작
        for (int y = 1; y <= yellow; y++)
        {
            // 노란색 카펫의 가로 값을 구함
            int x = yellow / y;

            // 노란색 카펫이 세로 값으로 완전히 나누어질 경우 실행
            if (yellow % y == 0)
            {
                // 노란색 카펫의 가로, 세로를 기반으로 갈색 카펫의 격자 수를 계산함
                if (brown == (2 * x + 2 * y + 4))
                {
                    // 갈색 카펫의 가로, 세로를 추가함
                    answer.Add(x + 2);                    
                    answer.Add(y + 2);
                    break;
                }
            }
        }
        
        return answer.ToArray();
    }
}