using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int N, int number) {
        // N과 number가 같을 때는 한 번만 사용하면 됨
        if (N == number) return 1;

        // DP 테이블 초기화
        List<HashSet<int>> dp = new List<HashSet<int>>();
        // 최대 8번까지 N을 사용할 수 있으므로, 각 사용 횟수에 대해 가능한 결과를 저장하는 DP리스트 초기화
        for (int i = 0; i <= 8; i++)
        {
            // HashSet은 중복 값을 자동으로 제거하여 효율적인 검색 보장
            dp.Add(new HashSet<int>());
        }

        // 초기 설정: 각 i에 대해 N...N(i번 반복)을 저장
        int baseNum = 0;
        for (int i = 1; i <= 8; i++)
        {
            // 'N', 'NN', 'NNN' 등을 DP 해쉬셋에 추가한다
            baseNum = baseNum * 10 + N;
            dp[i].Add(baseNum);
        }

        // 동적 프로그래밍을 이용한 계산
        // N을 사용하는 횟수(N을 i번 사용하여 만들 수 있는 모든 숫자 계산)
        for (int i = 1; i <= 8; i++)
        {
            // i 중에서 선택한 N의 사용 횟수
            // i 이전의 모든 가능한 사용 횟수에 대해 순회하면서 dp[j]와 dp[i - j]의 요소들을 결합하여 새로운 숫자를 생성
            for (int j = 1; j < i; j++)
            {
                // dp[j]의 모든 요소 a와 dp[i - j]의 모든 요소 b를 가지고 사칙연산 결과를 추가한다
                foreach (int a in dp[j])
                {
                    foreach (int b in dp[i - j])
                    {
                        dp[i].Add(a + b);
                        dp[i].Add(a - b);
                        dp[i].Add(a * b);
                        if (b != 0) dp[i].Add(a / b);
                    }
                }
            }
            // 목표 number를 찾은 경우
            if (dp[i].Contains(number))
            {
                return i;
            }
        }
        
        // 8번 안에 찾지 못한 경우
        return -1;
    }
}