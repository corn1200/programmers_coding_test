using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    // 유니온 파인드 자료구조
    static int[] parent;
    
    public int solution(int n, int[,] costs) {
        // 간선 리스트 생성 및 초기화
        var edges = new List<(int cost, int start, int end)>();
        // 입력으로 받은 비용 배열에서 간선 정보를 추출하여 간선 리스트에 저장한다
        for (int i = 0; i < costs.GetLength(0); i++)
        {
            edges.Add((costs[i, 2], costs[i, 0], costs[i, 1]));
        }

        // 간선을 비용 기준으로 정렬
        edges.Sort((a, b) => a.cost.CompareTo(b.cost));

        // 유니온 파인드 자료구조 초기화
        parent = new int[n];
        // 각 노드의 부모 노드를 자기 자신으로 초기화한다
        // 이 배열은 각 노드의 최상위 루트 노드를 추적하는 데 사용된다
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
        }

        // 최소 신장 트리 생성
        int totalCost = 0;
        // 정렬된 간선 리스트 순회
        foreach (var valueTuple in edges)
        {
            // 사이클을 형성하지 않는 간선(두 노드의 루트 노드가 다른 경우)만 선택
            if (Find(valueTuple.start) != Find(valueTuple.end))
            {
                // 노드에 유니온 연산을 실행함
                Union(valueTuple.start, valueTuple.end);
                // 선택된 간선의 비용을 총 비용에 추가한다
                totalCost += valueTuple.cost;
            }
        }

        // 총 비용 반환
        return totalCost;
    }
    
    // 파인드 연산
    static int Find(int node)
    {
        // 루트 노드를 찾은 경우
        if (parent[node] == node)
        {
            // 루트 노드를 반환
            return node;
        }
        // 부모 노드를 전부 업데이트
        parent[node] = Find(parent[node]);
        return parent[node];
    }

    // 유니온 연산
    static void Union(int node1, int node2)
    {
        // 각각의 루트 노드 찾기
        int root1 = Find(node1);
        int root2 = Find(node2);
        
        // 두 노드의 루트 노드가 다를 경우 합침
        if (root1 != root2)
        {
            parent[root2] = root1;
        }
    }
}