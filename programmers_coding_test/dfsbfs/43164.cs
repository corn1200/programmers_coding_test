using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // 그래프
    static Dictionary<string, SortedList<string, int>> graph = new Dictionary<string, SortedList<string, int>>();
    // 결과
    static List<string> result = new List<string>();

    public string[] solution(string[,] tickets)
    {
        // 그래프 구성
        for (int i = 0; i < tickets.GetLength(0); i++)
        {
            // 출발지, 도착지
            string src = tickets[i, 0];
            string dest = tickets[i, 1];

            // 그래프에 출발지 키가 없을 경우 실행
            if (!graph.ContainsKey(src))
            {
                // 현재 출발지에 새로운 정렬 리스트 추가(도착지 키를 알파벳 순서 정렬)
                graph[src] = new SortedList<string, int>();
            }

            // 그래프에 출발지-도착지 정보 없을 경우 실행
            if (!graph[src].ContainsKey(dest))
            {
                // 출발지-도착지 티켓을 0개로 초기화
                graph[src][dest] = 0;
            }

            // 출발지-도착지 티겟을 증가
            graph[src][dest]++;
        }

        // DFS 실행
        List<string> path = new List<string>();
        // ICN에서 출발
        path.Add("ICN");
        DFS("ICN", path, tickets.GetLength(0));

        // 결과 반환
        return result.ToArray();
    }

    // DFS 함수
    static bool DFS(string current, List<string> path, int ticketCount)
    {
        // 현재 경로 길이가 항공권 + 1과 같을 경우
        if (path.Count == ticketCount + 1)
        {
            // 현재 경로를 결과에 반영하고 true 반환
            result = new List<string>(path);
            return true;
        }

        // 그래프에 출발지 정보 없을 경우 false 반환
        if (!graph.ContainsKey(current))
        {
            return false;
        }

        // 현재 항공을 출발지로 삼는 항공권 순회
        foreach (var pair in graph[current].ToList())
        {
            // 도착지, 티켓 갯수
            string destination = pair.Key;
            int count = pair.Value;

            // 티켓이 1개 이상일 경우
            if (count > 0)
            {
                // 해당 출발지-도착지 티켓을 한개 사용
                graph[current][destination]--;
                // 도착지를 경로에 추가
                path.Add(destination);

                // 해당 경로로 이동이 가능할 경우 true 반환
                if (DFS(destination, path, ticketCount))
                {
                    return true;
                }

                // 이동이 불가능하면 경로 추가를 취소
                path.RemoveAt(path.Count - 1);
                // 티켓 사용을 되돌린다
                graph[current][destination]++;
            }
        }

        return false;
    }
}