using System;
using System.Collections.Generic;

public class Solution
{
    public int solution(int n, int[,] wires)
    {
        // 가장 작은 차이의 트리 갯수
        int minDifference = int.MaxValue;
        // 그래프 생성
        Graph graph = new Graph(n);

        // 그래프에 모든 연결을 추가
        for (int i = 0; i < wires.GetLength(0); i++)
        {
            graph.AddEdge(wires[i, 0], wires[i, 1]);
        }

        // 각 연결을 하나씩 제거하며 두 그룹의 차이 계산
        for (int i = 0; i < wires.GetLength(0); i++)
        {
            // 그래프에서 간선 제거
            graph.RemoveEdge(wires[i, 0], wires[i, 1]);
            // 간선 제거한 노드에서 DFS 출발 후 트리 크기 반환
            int groupSize = graph.DFS(wires[i, 0]);
            // 두 트리 집단의 차이 구하기
            int difference = Math.Abs(n - 2 * groupSize);
            // 최소 트리 집단 크기 차이 업데이트
            minDifference = Math.Min(minDifference, difference);
            // 연결 복원
            graph.AddEdge(wires[i, 0], wires[i, 1]);
        }

        return minDifference;
    }

    // 그래프 클래스
    public class Graph
    {
        // 인접 노드 리스트
        private List<int>[] adjacencyList;

        // 방문 결과
        private bool[] visited;

        // 그래프 생성자
        public Graph(int vertices)
        {
            // 인접 노드 리스트 초기화
            adjacencyList = new List<int>[vertices + 1];

            // 노드 갯수만큼 순회
            for (int i = 1; i <= vertices; i++)
            {
                // 현재 노드의 인접 노드 리스트 추가
                adjacencyList[i] = new List<int>();
            }
        }

        // 간선 추가 함수
        public void AddEdge(int src, int dest)
        {
            // A에서 B로 가는 간선을 서로 추가한다
            adjacencyList[src].Add(dest);
            adjacencyList[dest].Add(src);
        }

        // 간선 제거 함수
        public void RemoveEdge(int src, int dest)
        {
            // A에서 B로 가는 간선을 서로 제거한다
            adjacencyList[src].Remove(dest);
            adjacencyList[dest].Remove(src);
        }

        // DFS 함수
        public int DFS(int startVertex)
        {
            // 노드 방문 배열을 초기화한다
            visited = new bool[adjacencyList.Length];
            // 재귀 함수 실행
            return Explore(startVertex);
        }

        // 재귀 함수
        private int Explore(int vertex)
        {
            // 현재 노드를 방문 처리함
            visited[vertex] = true;

            // 트리 사이즈
            int size = 1;

            // 현재 노드의 이웃 노드 순회
            foreach (int neighbor in adjacencyList[vertex])
            {
                // 아직 방문하지 않은 이웃 노드일 경우 실행
                if (!visited[neighbor])
                {
                    // 이웃 트리의 크기 합산
                    size += Explore(neighbor);
                }
            }

            // 트리 사이즈 반환
            return size;
        }
    }
}