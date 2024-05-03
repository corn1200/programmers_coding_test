using System;

public class Solution {
    public int solution(int n, int[,] computers) {
        // 컴퓨터 방문 여부
        bool[] visited = new bool[n];
        // 네트워크 갯수
        int networkCount = 0;

        // 모든 컴퓨터 순회
        for (int i = 0; i < n; i++)
        {
            // 방문하지 않은 컴퓨터일 경우 실행
            if (!visited[i])
            {
                // DFS 시작
                DFS(i, visited, computers, n);
                // 새 네트워크 발견 시 카운트 증가
                networkCount++;
            }
        }

        // 네트워크 갯수 반환
        return networkCount;
    }
    
    private static void DFS(int node, bool[] visited, int[,] computers, int n)
    {
        // 현재 노드 방문 표시
        visited[node] = true;

        // 전체 컴퓨터 순회
        for (int connected = 0; connected < n; connected++)
        {
            // 현재 컴퓨터와 연결된 컴퓨터가 있고 아직 방문하지 않았을 시 실행 
            if (computers[node, connected] == 1 && !visited[connected])
            {
                // 연결된 다른 컴퓨터 방문
                DFS(connected, visited, computers, n);
            }
        }
    }
}