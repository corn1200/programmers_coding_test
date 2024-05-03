using System;

public class Solution {
    public int solution(int n, int[,] results) {
        // 승리 관계 그래프 초기화
        bool[,] graph = new bool[n + 1, n + 1];

        // 경기 결과 입력
        for (int i = 0; i < results.GetLength(0); i++)
        {
            // 주어진 경기 결과를 바탕으로 그래프 업데이트
            int winner = results[i, 0];
            int loser = results[i, 1];
            // 승자에서 패자로 단방향 간선 연결
            graph[winner, loser] = true;
        }

        // 플로이드-워셜 알고리즘
        for (int k = 1; k <= n; k++)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    // i번 선수가 k번 선수를 이기고, k번 선수가 j번 선수를 이긴 경우
                    if (graph[i, k] && graph[k, j])
                    {
                        // i번 선수는 j번 선수를 이길 수 있기 때문에 간선을 연결한다
                        graph[i, j] = true;
                    }
                }
            }
        }

        // 순위를 확정할 수 있는 선수 수 계산
        int count = 0;
        // 선수 순회
        for (int i = 1; i <= n; i++)
        {
            // 승패를 알 수 있는 선수 갯수
            int known = 0;
            // 다른 모든 선수 순회
            for (int j = 1; j <= n; j++)
            {
                // 승패를 알 수 있는 경우
                if (graph[i, j] || graph[j, i])
                {
                    // 승패를 아는 선수 증가
                    known++;
                }
            }
            
            // 자기 자신을 제외하고 모든 선수와의 관계를 알 수 있어야 함
            if (known == n - 1)
            {
                // 순위 확정 가능한 선수 증가
                count++;
            }
        }

        return count;
    }
}