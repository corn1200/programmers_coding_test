using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int n, int[,] edge) {
        // 그래프 초기화
        List<int>[] graph = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<int>();
        }

        // 간선 정보 입력
        for (int i = 0; i < edge.GetLength(0); i++)
        {
            // 양방향 간선을 양쪽 모두에 추가한다
            int a = edge[i, 0];
            int b = edge[i, 1];
            graph[a].Add(b);
            graph[b].Add(a);
        }

        // 각 노드까지의 최단 거리 저장
        int[] distances = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            // 초기에 모든 노드의 거리는 최대값
            distances[i] = int.MaxValue;
        }
        // 시작 노드의 거리는 0으로 설정하고 우선순위 큐에 추가한다
        distances[1] = 0;
        var pq = new SortedSet<(int distance, int node)>();
        pq.Add((0, 1));

        // 우선순위 큐 탐색
        while (pq.Count > 0)
        {
            // 우선순위 큐에서 요소 하나를 꺼냄
            var current = pq.Min;
            pq.Remove(current);

            // 현재 노드의 이웃 노드 순회
            foreach (int neighbor in graph[current.node])
            {
                // 이웃 노드까지의 거리를 갱신
                int newDistance = current.distance + 1;
                // 새로 계산된 거리가 기존 거리보다 짧을 경우 실행
                if (newDistance < distances[neighbor])
                {
                    // 갱신 전 거리를 가진 노드를 큐에서 제거함
                    pq.Remove((distances[neighbor], neighbor));
                    // 갱신 후 거리를 노드에 저장하고 큐에 추가
                    distances[neighbor] = newDistance;
                    pq.Add((newDistance, neighbor));
                }
            }
        }

        // 가장 먼 거리
        int maxDistance = 0;
        // 가장 먼 노드 갯수
        int count = 0;
        // 노드 순회
        for (int i = 1; i <= n; i++)
        {
            // 노드가 거리가 갱신되지 않았을 경우 넘어감
            if (distances[i] == int.MaxValue)
            {
                continue;
            }
            
            // 현재 거리 최대값보다 노드 거리가 길 경우
            if (distances[i] > maxDistance)
            {
                // 거리 최대값 갱신
                maxDistance = distances[i];
                // 가장 먼 노드 갯수 초기화
                count = 1;
            }
            // 현재 거리 최대값과 노드 거리가 같을 경우
            else if (distances[i] == maxDistance)
            {
                // 가장 먼 노드 갯수 증가
                count++;
            }
        }

        return count;
    }
}