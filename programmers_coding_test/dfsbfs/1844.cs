using System;
using System.Collections.Generic;

class Solution {
    public int solution(int[,] maps) {
        // n, m의 크기 초기화
        int n = maps.GetLength(0);
        int m = maps.GetLength(1);
        
        // 4개의 방향 (하, 상, 우, 좌)
        int[,] directions = { {1, 0}, {-1, 0}, {0, 1}, {0, -1} };
        // 방문 여부
        bool[,] visited = new bool[n, m];
        // x, y 좌표와 거리
        Queue<(int, int, int)> queue = new Queue<(int, int, int)>();

        // 시작 지점 방문
        queue.Enqueue((0, 0, 1));
        visited[0, 0] = true;

        // 전부 방문할 때까지 반복
        while (queue.Count > 0)
        {
            // 방문한 곳의 데이터 추출
            var (x, y, dist) = queue.Dequeue();
            
            // 목표 지점에 도달한 경우
            if (x == n - 1 && y == m - 1)
            {
                return dist;
            }

            // 4개 방향 순회
            for (int i = 0; i < directions.GetLength(0); i++)
            {
                // 다음 이동할 x, y 좌표 지정
                int nextX = x + directions[i, 0];
                int nextY = y + directions[i, 1];
                
                // 맵의 범위를 벗어나지 않고, 벽이 아니며, 방문하지 않은 경우
                if (nextX >= 0 && nextX < n && nextY >= 0 && nextY < m && maps[nextX, nextY] == 1 && !visited[nextX, nextY])
                {
                    // 다음 이동할 곳을 방문한 것으로 체크
                    visited[nextX, nextY] = true;
                    // 다음 방문할 곳 큐에 추가하고 거리 + 1
                    queue.Enqueue((nextX, nextY, dist + 1));
                }
            }
        }

        // 모든 가능한 경로를 탐색한 후 목표 지점에 도달하지 못한 경우
        return -1;
    }
}